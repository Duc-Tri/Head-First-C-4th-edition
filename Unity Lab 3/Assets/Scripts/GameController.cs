using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject OneBallPrefab;

    void Start()
    {
        InvokeRepeating("AddABall", 0.5f, 1);
    }

    void AddABall()
    {
        Instantiate(OneBallPrefab);
    }

    void Update()
    {

    }
}
