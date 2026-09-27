using UnityEngine;

public class Dart : MonoBehaviour
{
    public bool hasCollided;
    private TrailRenderer trail;

    private void Start()
    {
        trail = GetComponent<TrailRenderer>();
        Invoke("Destroy", 5f);
    }

    public void OnCollisionEvent()
    {
        if (hasCollided) return;
        
        CancelInvoke();

        //Debug.Log("Colidi com alvo!");
        hasCollided = true;

        GameController.gameController.uiController.UpdatePoints();

        if (GameController.gameController.darts <= 1)
        {
            GameController.gameController.NextRound();
        }
        else
        {
            GameController.gameController.uiController.EndRound();
        }
            

        GetComponent<MeshRenderer>().enabled = false;
        trail.enabled = false;

        //Destroy();
        //GameController.gameController.pController.RemoveFromPhysicsPool(GetComponent<PBody>());
        // Destroy(gameObject);
    }

    private void Destroy()
    {
        OnCollisionEvent();

       // GameController.gameController.pController.RemoveFromPhysicsPool(GetComponent<PBody>());

        GetComponent<MeshRenderer>().enabled = false;

       // Destroy(gameObject);
    }
}
