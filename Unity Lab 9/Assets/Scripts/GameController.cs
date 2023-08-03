using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<GameObject> TargetPrefabs;

    public int TargetCount = 20;
    private System.Random random = new System.Random();

    public static GameController Instance;

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < TargetCount; i++)
        {
            Instantiate(TargetPrefabs[random.Next(0, 3)]);
        }
    }

    void Update()
    {

    }

    internal void PlayerOutOfBounds()
    {
        Debug.Log("PlayerOutOfBounds");
    }
}
