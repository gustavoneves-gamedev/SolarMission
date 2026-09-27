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
    public Cannon cannon;
    public PController pController;
    public CameraFollow mainCamera;

    private void Awake()
    {
        gameController = this;
    }

    public void BeginPlay()
    {
        SetWind();
        //SetTargetPosition();
        isPlaying = true;
        cannon.canFire = true;
        uiController.UpdatePoints();
        uiController.inGameMenu.SetActive(true);
    }

    private void SetTargetPosition()
    {
        target.transform.position = Vector3.forward * Random.Range(10f, 30f) + Vector3.up * 5f + Vector3.left * 3.37f;
    }

    private void SetWind()
    {
        windForce.x = Random.Range(-5f, 5f);
        windForce.y = Random.Range(-5f, 5f);
        windForce.z = Random.Range(-5f, 5f);
        //windForce.y = 0;
        //windForce.z = 0;

        //windForce *= Random.Range(0f, 5f);
        uiController.UpdateWind();
    }

    public void NextRound()
    {
        darts--;
        mainCamera.isFollowingDart = false;

        if (darts <= 0)
        {
            EndGame();
        }
        else
        {
            Time.timeScale = 1f;

            //Destroy(currentDart);
            round++;

            cannon.canFire = true;

            uiController.UpdateDarts(darts);
            SetWind();
        }
    }
    

    public void AddPoints(float pointsToAdd)
    {
        points += pointsToAdd;
        //uiController.UpdateDarts(totalPoints);
    }

    private void EndGame()
    {
        isPlaying = false;
        uiController.EndGame();
    }

    public void ResetGame()
    {
        darts = 3;
        points = 0;
        BeginPlay();
    }

}
