using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject roundEndMenu;

    public TextMeshProUGUI points;

    public GameObject[] dartsIndicator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController.gameController.uiController = this;

        mainMenu.SetActive(true);

        UpdatePoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginPlay()
    {
        GameController.gameController.BeginPlay();
    }

    public void UpdatePoints()
    {
        points.text = "Pontos: " + GameController.gameController.points;
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

}
