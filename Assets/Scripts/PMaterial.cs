using UnityEngine;

[CreateAssetMenu(fileName = "Material", menuName = "MyPhysics/MyMaterial")]
public class PMaterial : ScriptableObject
{
    public enum Type { MAX, MIN, MEDIA, MULT }
    public Type type;
    public float bounce;
}
