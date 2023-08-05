using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public GameObject RobotPrefab;

    public bool GameOver { get; private set; } = true;
    public int Score { get; private set; }

    public Button PlayAgainButton;

    private List<GameObject> ActiveRobots;
    private void Awake()
    {
        ActiveRobots = new List<GameObject>();
        ResetLevel(10);
    }

    private void ResetLevel(int numberRobots)
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

    private void Update()
    {
    }

    public void StartGame()
    {
        PlayAgainButton.gameObject.SetActive(false);
        Score = 0;
        GameOver = false;
        ResetLevel(2);
    }

    public void PlayerDied()
    {
        GameOver = true;
        PlayAgainButton.gameObject.SetActive(true);
    }

}