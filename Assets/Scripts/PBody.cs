using System.Collections.Generic;
using UnityEngine;

public class PBody : MonoBehaviour
{
    public float mass, gravityScale;
    public Vector3 velocity, initialForce, totalForce, gravityForce;
    public PShape shape;
    public bool isKinematic;

    [SerializeField] private List<Vector3> forces = new List<Vector3>();

    private void Start()
    {
        //totalForce = initialForce;
        //TotalForce(initialForce);

        gravityForce = PConstants.GRAVITY * gravityScale;
    }


    public void PUpdate(float t)
    {
        if (!isKinematic) Dynamic(t);        

        Kinamatic(t);

        RefreshPosition();
    }

    private void Dynamic(float t)
    {
        // a = F / m + g
        Vector3 acceleration = totalForce/ mass + gravityForce;

        //v = v + a * t
        velocity = velocity + acceleration * t;
    }

    private void Kinamatic(float t)
    {
        //p = p0 + v * t
        shape.position = shape.position + velocity * t;

    }

    private void RefreshPosition()
    {
        shape.UpdatePosition(shape.position);
        transform.position = shape.position;
    }

    public void OnPCollisionEnter(PBody other)
    {
        Debug.Log("Colide com " + other.gameObject.name);
    }


}
