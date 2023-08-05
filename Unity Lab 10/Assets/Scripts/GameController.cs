using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static Player player = null;

    [SerializeField]
    public GameObject RobotPrefab;

    public bool GameOver { get; private set; } = true;
    public int Score { get; private set; }

    [SerializeField]
    public Transform GameOverCanvas;

    private List<GameObject> ActiveRobots = new List<GameObject>();

    private int totalRobots;
    private int liveRobots; // => ActiveRobots.Count;

    public Text scoreText;
    public Text RobotsLeftText;

    private void Awake()
    {
        //ResetLevel(10);

        if (GameOverCanvas == null)
            GameOverCanvas = GameObject.FindGameObjectWithTag("Game Over Screen").transform;

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void ResetLevel(int numberRobots)
    {
        foreach (var robot in GameObject.FindGameObjectsWithTag("Robot"))
            Destroy(robot);

        liveRobots = numberRobots;
        totalRobots = numberRobots;

        player.StopMoving();

        for (int i = 0; i < numberRobots; i++)
        {
            var robot = Instantiate(RobotPrefab);
            Vector3 position;
            do
            {
                position = RandomPointHelper.RandomPointOnMesh(robot.transform.position, 100) + Vector3.up;
                robot.transform.position = position;
            } while (Vector3.Distance(position, player.transform.position) < 5);
        }
    }

    private void ResetLevel1(int numberRobots)
    {
        int delta = numberRobots - ActiveRobots.Count;

        if (delta > 0)
        {
            for (int i = 0; i < delta; i++)
                ActiveRobots.Add(Instantiate(RobotPrefab));
        }
        else
        {
            delta = Math.Abs(delta);
            for (int i = 0; i < delta; i++)
            {
                Destroy(ActiveRobots[0]);
                ActiveRobots.RemoveAt(0);
            }
        }
    }

    public void StartGame()
    {
        Score = 0;
        GameOver = false;
        UpdateButtonAndTexts();
        ResetLevel(2);
    }

    private void UpdateButtonAndTexts()
    {
        for (int i = 0; i < GameOverCanvas.childCount; i++)
        {
            GameOverCanvas.GetChild(i).gameObject.SetActive(GameOver);
        }

        /*
        PlayAgainButton.gameObject.SetActive(GameOver);
        foreach (var go in GameObject.FindGameObjectsWithTag("Game Over Screen"))
            go.SetActive(GameOver);
        */
    }

    public void PlayerDied()
    {
        GameOver = true;
        UpdateButtonAndTexts();
    }

    public void RobotDied()
    {
        Score += 10;
        liveRobots--;
        if (liveRobots == 0)
            ResetLevel(totalRobots + 1);
    }

    private void Update()
    {
        scoreText.text = Score.ToString();
        RobotsLeftText.text = $"Robots left: {liveRobots} of {totalRobots}";
    }



}