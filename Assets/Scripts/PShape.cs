using UnityEngine;

public abstract class PShape : MonoBehaviour
{
    public Vector3 position;
    public bool isStatic;
    public PMaterial material;

    private void Awake()
    {
        position = transform.position;
    }

    public abstract void UpdatePosition(Vector3 shapePosition);

    public abstract bool GetCollision(PShape other, out PCollision collision);

}
