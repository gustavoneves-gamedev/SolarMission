using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject inGameMenu;
    public GameObject roundEndMenu;
    public GameObject endGameMenu;

    public TextMeshProUGUI points;
    public TextMeshProUGUI endScreenPoints;
    public TextMeshProUGUI windText;

    public GameObject[] dartsIndicator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController.gameController.uiController = this;

        mainMenu.SetActive(true);

        UpdatePoints();
    }
        

    public void BeginPlay()
    {
        GameController.gameController.BeginPlay();
    }

    public void UpdatePoints()
    {
        points.text = "Pontos: " + GameController.gameController.points;
    }

    public void UpdateWind()
    {
        windText.text = "Vento: " + GameController.gameController.windForce.x + " , " +
            GameController.gameController.windForce.y + " , " + GameController.gameController.windForce.z;
    }

    public void UpdateDarts(int dartToConsume)
    {
        dartsIndicator[dartToConsume].SetActive(false);
    }

    public void EndRound()
    {
        Time.timeScale = 0f;
        roundEndMenu.SetActive(true);
    }

    public void StartRound()
    {
        GameController.gameController.NextRound();
    }

    public void EndGame()
    {
        inGameMenu.SetActive(false);
        endScreenPoints.text = "Pontos: " + GameController.gameController.points;
        endGameMenu.SetActive(true);
    }

    public void RestartGame()
    {
        foreach (GameObject dartImage in dartsIndicator)
        {
            dartImage.SetActive(true);
        }
        //UpdatePoints();
        GameController.gameController.ResetGame();
        
    }

    public void Quit()
    {
        Application.Quit();
    }

}
