using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text ScoreText;
    public Text BallsLeftText;
    public Button PlayAgain;

    public List<GameObject> TargetPrefabs;

    public int TargetCount = 20;
    private System.Random random = new System.Random();

    public static GameController Instance;

    public int BallsPerGame = 5;
    public bool GameOver { get; private set; } = true;
    private int Score;
    private int BallsLeft;

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < TargetCount; i++)
        {
            Instantiate(TargetPrefabs[random.Next(0, 3)]);
        }
    }

    private void Start()
    {
        StartGame();
    }

    void Update()
    {
        ScoreText.text = "Score: " + Score;
        BallsLeftText.text = "Balls left: " + BallsLeft;
    }

    public void StartGame()
    {
        BallsLeft = BallsPerGame;
        Score = 0;
        GameOver = false;
        PlayAgain.gameObject.SetActive(false);
    }

    public void PlayerScored()
    {
        Score++;
        Instantiate(TargetPrefabs[random.Next(0, 3)]);
    }

    public void BallLost()
    {
        if (--BallsLeft <= 0)
        {
            GameOver = true;
            PlayAgain.gameObject.SetActive(true);
        }
    }

}
