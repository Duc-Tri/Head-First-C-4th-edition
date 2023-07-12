using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OneBallBehaviour : MonoBehaviour
{
    private bool RotateFunction = true;
    //-----------------------------------------
    public float XRotation = 0;
    public float YRotation = 1;
    public float ZRotation = 0;
    public float DegreesPerSecond = 180;

    //-----------------------------------------
    public float XSpeed;
    public float YSpeed;
    public float ZSpeed;
    public float Multiplier = 0.75F;
    public int TooFar = 5;

    //-----------------------------------------
    [SerializeField]
    private int BallNumber;

    private static int BallCount = 0;


    void Start()
    {
        BallNumber = BallCount++;
        RotateFunction = (Random.value > 0.5f);

        ResetBall();
    }

    void ResetBall()
    {
        transform.position = new Vector3(3 - Random.value * 6, 3 - Random.value * 6, 3 - Random.value * 6);

        XSpeed = Multiplier - Random.value * Multiplier * 2;
        YSpeed = Multiplier - Random.value * Multiplier * 2;
        ZSpeed = Multiplier - Random.value * Multiplier * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (RotateFunction)
            RotateAround();
        else
            Translate();
    }

    private void Translate()
    {
        transform.Translate(Time.deltaTime * XSpeed, Time.deltaTime * YSpeed, Time.deltaTime * ZSpeed);

        XSpeed += Multiplier - Random.value * Multiplier * 2;
        YSpeed += Multiplier - Random.value * Multiplier * 2;
        ZSpeed += Multiplier - Random.value * Multiplier * 2;

        if ((Mathf.Abs(transform.position.x) > TooFar) ||
            (Mathf.Abs(transform.position.y) > TooFar) ||
            (Mathf.Abs(transform.position.z) > TooFar))
        {
            ResetBall();
        }
    }

    private void RotateAround()
    {
        Vector3 axis = new Vector3(XRotation, YRotation, ZRotation);
        transform.RotateAround(Vector3.zero, axis, DegreesPerSecond * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        GameController controller = Camera.main.gameObject.GetComponent<GameController>();
        if (!controller.GameOver)
        {
            controller.ClickOnBall();
            Destroy(gameObject);
        }
    }
}
