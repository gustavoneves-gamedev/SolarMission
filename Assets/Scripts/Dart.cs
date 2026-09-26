using UnityEngine;

public class Dart : MonoBehaviour
{
    public bool hasCollided;

    private void Start()
    {
        
    }

    public void OnCollisionEvent()
    {
        if (hasCollided) return;
        
        Debug.Log("Colidi com alvo!");
        hasCollided = true;

        GameController.gameController.uiController.UpdatePoints();

        GameController.gameController.uiController.EndRound();


    }
}
