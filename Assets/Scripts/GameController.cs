using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    public float points;
    //public float totalPoints;

    public Vector3 windForce;
    private float rb;

    public int round = 1;
    public int darts = 3;

    public GameObject target;
    public float targetDistance;

    public bool isPlaying;

    public UIController uiController;
    public Dart currentDart;

    private void Awake()
    {
        gameController = this;
    }

    public void BeginPlay()
    {
        SetWind();
        //SetTargetPosition();
        isPlaying = true;
    }

    private void SetTargetPosition()
    {
        target.transform.position = Vector3.forward * Random.Range(10f, 30f) + Vector3.up * 5f + Vector3.left * 3.37f;
    }

    private void SetWind()
    {
        windForce.x = Random.Range(0f, 1f);
        windForce.y = Random.Range(0f, 1f);
        windForce.z = Random.Range(0f, 1f);

        windForce *= Random.Range(0f, 5f);
    }

    public void NextRound()
    {
        Time.timeScale = 1f;


        Destroy(currentDart);
        round++;
        darts--;
        uiController.UpdateDarts(darts);
        SetWind();
    }
    

    public void AddPoints(float pointsToAdd)
    {
        points += pointsToAdd;
        //uiController.UpdateDarts(totalPoints);
    }


}
