using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject OneBallPrefab;
    public TextMeshProUGUI ScoreText;
    public Button PlayAgainButton;
    //-------------------------------------------
    public int Score = 0;
    public bool GameOver = true;
    public int NumberOfBalls = 0;
    public int MaximumBalls = 10;


    void Start()
    {
        InvokeRepeating("AddABall", 0.5f, 1);
    }

    void AddABall()
    {
        if (!GameOver)
        {
            Instantiate(OneBallPrefab);
            NumberOfBalls++;
            if (NumberOfBalls >= MaximumBalls)
            {
                GameOver = true;
                PlayAgainButton.gameObject.SetActive(true);
            }
        }
    }

    public void ClickOnBall()
    {
        Score++;
        NumberOfBalls--;
    }

    public void StartGame()
    {
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
            Destroy(ball);

        PlayAgainButton.gameObject.SetActive(false);
        Score = 0;
        NumberOfBalls = 0;
        GameOver = false;
    }

    private void Update()
    {
        ScoreText.text = Score.ToString();
    }

}
