using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject OneBallPrefab;
    public float addBallFrequency = 1; // in seconds
    public float addBallHeight = 10; // y

    void Start()
    {
        InvokeRepeating("DropABall", 0, addBallFrequency);
    }

    void DropABall()
    {
        GameObject ball = Instantiate(OneBallPrefab);
        ball.transform.position = new Vector3(20 - Random.value * 40,
                                            addBallHeight,
                                            10 - Random.value * 20);
    }

    void Update()
    {

    }
}
