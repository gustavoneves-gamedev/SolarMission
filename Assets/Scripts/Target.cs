using UnityEngine;

public class Target : MonoBehaviour
{

    public float points = 10;
    public bool hasCollided;

   
    public void OnCollisionEvent()
    {
        
        //if (hasCollided) return;

        GameController.gameController.AddPoints(points);
        //hasCollided = true;
    }
}
