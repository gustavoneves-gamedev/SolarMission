using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PBody : MonoBehaviour
{
    public float mass, gravityScale;
    public Vector3 velocity, initialForce, totalForce;
    public PShape shape;
    public bool isKinematic;    

    [SerializeField] private List<Vector3> forces = new List<Vector3>();

    private void Start()
    {
        totalForce = initialForce;
    }


    public void PUpdate(float t)
    {
       if(!isKinematic) Dynamic(t);

        Kinamatic(t);

        RefreshPosition();
    }

    private void Dynamic(float t)
    {
        // a = F / m + g
        Vector3 acceleration = totalForce/mass;

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
        totalForce += forceToAdd;
        return totalForce;
        
    }

    
}
