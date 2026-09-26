using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour
{
    [SerializeField] private List<PBody> bodies = new List<PBody>();
    //[SerializeField] private float G = 0.0000000000667f;

    [Range(1f, 10f)]
    public float t = 1;

    void Start()
    {
        bodies.AddRange(FindObjectsByType<PBody>(FindObjectsSortMode.None));

        Time.timeScale = t;
    }


    void FixedUpdate()
    {
        if (!GameController.gameController.isPlaying) return;
        
        foreach (PBody b1 in bodies)
        {
            if (b1.shape.isStatic) continue;


            foreach (PBody b2 in bodies)
            {
                if (b1.Equals(b2)) continue;
                if (b1.shape.GetCollision(b2.shape, out PCollision hit))
                {
                    //Debug.Log("Colidiu");
                    Constraints(b1, b2, hit);
                    ResolveCollision(b1, b2, hit);
                    b1.OnPCollisionEnter(b2);
                    b2.OnPCollisionEnter(b1);
                }
            }

            b1.PUpdate(Time.fixedDeltaTime);
            //b1.totalForce = Vector3.zero;            
        }
    }

    private void Constraints(PBody b1, PBody b2, PCollision hit)
    {
        if (b2.shape.isStatic)
        {
            b1.shape.position += hit.normal * hit.penetration;
        }
        else
        {
            float mt = b1.mass + b2.mass;


            b1.shape.position += hit.normal * hit.penetration * (b2.mass / mt);
            b2.shape.position -= hit.normal * hit.penetration * (b1.mass / mt); //Não entendi o porquê desta conta em específico
            //porque todos os objetos serão b1 em algum momento então deixa para calcular o b2 quando ele for o b1
        }
    }

    private void ResolveCollision(PBody b1, PBody b2, PCollision hit)
    {
        if (b2.shape.isStatic)
        {
            b1.velocity += hit.normal * b1.velocity.magnitude * (1 + GetBounce(b1.shape.material, b2.shape.material));
        }
        else
        {
            float mt = b1.mass + b2.mass;
            float vt = (b1.velocity + b2.velocity).magnitude;
            float bounce = GetBounce(b1.shape.material, b2.shape.material);

            b1.velocity += hit.normal * vt * (b2.mass / mt) * (1 + bounce);
            b2.velocity -= hit.normal * vt * (b1.mass / mt) * (1 + bounce); //Não entendi o porquê desta conta em específico
            //porque todos os objetos serão b1 em algum momento então deixa para calcular o b2 quando ele for o b1
        }
    }

    private float GetBounce(PMaterial m1, PMaterial m2)
    {
        //float bounce = 1;
        switch (m1.type)
        {
            case PMaterial.Type.MAX:
                return (m1.bounce > m2.bounce) ? m1.bounce : m2.bounce;
            case PMaterial.Type.MIN:
                return (m1.bounce < m2.bounce) ? m1.bounce : m2.bounce;
            case PMaterial.Type.MEDIA:
                return (m1.bounce + m2.bounce) * .5f;
            case PMaterial.Type.MULT:
                return m1.bounce * m2.bounce;
            default: return 1;

        }
    }

}
