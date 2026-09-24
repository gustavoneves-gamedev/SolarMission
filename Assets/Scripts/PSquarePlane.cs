using UnityEngine;

public class PSquarePlane : PShape
{
    public float radius;

    [SerializeField] private Vector3[] points = new Vector3[4];
    [SerializeField] private Vector3[] centerToPoints = new Vector3[4];
    [SerializeField] private Vector3 center;
    public float l;

    private void Start()
    {
        center = transform.position;
        
        
        points[0] = center + (Vector3.left * l/2) + (Vector3.forward * l / 2);
        centerToPoints[0] = points[0] - center; 

        points[1] = points[0] + (Vector3.right * l);
        centerToPoints[1] = points[1] - center;

        points[2] = points[1] + (Vector3.back * l);
        centerToPoints[2] = points[2] - center;

        points[3] = points[2] + (Vector3.left * l);
        centerToPoints[3] = points[3] - center;


        center = (((points[0] + points[1])/2) + ((points[2] + points[3]) / 2))/2;

        transform.localScale *= l * 0.1f;
    }

    public override void UpdatePosition(Vector3 shapePosition)
    {
        center = shapePosition;
        
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = center + centerToPoints[i];
        }
    }

    public override bool GetCollision(PShape other, out PCollision hit)
    {

        PSphere sphere = (PSphere)other;
        hit = new PCollision();
        if (other == null) return false;

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
