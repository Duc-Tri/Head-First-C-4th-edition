using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject OneBallPrefab;
    public float addBallFrequency = 1; // in seconds
    public float addBallHeight = 10; // y

    public int Score = 0;
    public static GameController Instance;

    public bool GameOver = true;
    public int MaxScore = 10;
    public Text ScoreText;
    public Button playAgainButton;

    private float GameTimer = 0f;
    public Text TimerText;
    
    [SerializeField]
    public AudioSource audioDestroyBall;

    private void Awake()
    {
        SetGameOver(true);
        Instance = this;
    }

    void Start()
    {
        InvokeRepeating("DropABall", 0, addBallFrequency);
    }

    void DropABall()
    {
        if (!GameOver)
        {
            GameObject ball = Instantiate(OneBallPrefab);
            ball.transform.position = new Vector3(20 - Random.value * 40,
                                                addBallHeight,
                                                10 - Random.value * 20);
        }
    }

    void Update()
    {
        ScoreText.text = $"Score: {Score} of {MaxScore}";
        if (!GameOver)
        {
            GameTimer += Time.deltaTime;
        }
        TimerText.text = $"Time elapsed: {GameTimer:0.00}";
    }

    public void CollideWithBall()
    {
        Score++;
        if (Score >= MaxScore)
        {
            SetGameOver(true);
        }
    }

    private void SetGameOver(bool v)
    {
        GameOver = v;
        playAgainButton.gameObject.SetActive(v);
        Score = 0;
        GameTimer = 0;
    }

    public void StartGame()
    {
        SetGameOver(false);
    }

}
