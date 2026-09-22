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
        TotalForce(initialForce);
    }


    public void PUpdate(float t)
    {
        if (!isKinematic) Dynamic(t);

        if (initialForce.magnitude > 0 && initialForce != Vector3.zero)
        {
            initialForce.x = initialForce.x >= 0 ? (initialForce.x - 1) : 0;
            initialForce.y = initialForce.y >= 0 ? (initialForce.y - 1) : 0;
            initialForce.z = initialForce.z >= 0 ? (initialForce.z - 1) : 0;
        }
        else
        {
            initialForce = Vector3.zero;
        }

        Kinamatic(t);

        RefreshPosition();
    }

    private void Dynamic(float t)
    {
        // a = F / m + g
        Vector3 acceleration = TotalForce(initialForce) / mass;

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
        transform.position = shape.position;
    }

    public void OnPCollisionEnter(PBody other)
    {
        Debug.Log("Colide com " + other.gameObject.name);
    }

    public Vector3 TotalForce(Vector3 forceToAdd)
    {
        totalForce = forceToAdd + gravityForce;
        return totalForce;

    }

    public Vector3 GravityForce(Vector3 gravityForceToAdd)
    {
        gravityForce += gravityForceToAdd;
        TotalForce(Vector3.zero);
        return gravityForce;

    }

}
