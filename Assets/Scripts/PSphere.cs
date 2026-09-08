using UnityEngine;

public class PSphere : PShape
{
    public float radius;

    

    public override bool GetCollision(PShape other, out PCollision hit)
    {
        
        PSphere sphere = (PSphere)other;
        hit = new PCollision();
        if(other == null) return false;

        Vector3 d = position - sphere.position;
        hit.penetration = (radius + sphere.radius) - d.magnitude;

        if (hit.penetration < 0) return false;

        hit.penetration += 0.01f;
        hit.normal = d.normalized;
        hit.position = sphere.position + hit.normal * sphere.radius;

        //hit = null;
        return true;
    }

}
