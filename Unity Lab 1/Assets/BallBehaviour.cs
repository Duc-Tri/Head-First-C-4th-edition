using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float XRotation = 0;
    public float YRotation = 1;
    public float ZRotation = 0;
    public float DegreesPerSecond = 180;

    public Vector3 centerRotation = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 axis = new Vector3(XRotation, YRotation, ZRotation);

        //transform.Rotate(axis, DegreesPerSecond * Time.deltaTime);

        transform.RotateAround(centerRotation, axis, DegreesPerSecond * Time.deltaTime);

        Debug.DrawRay(centerRotation, axis, Color.red);
        if (Time.frameCount % 10 == 0)
            Debug.DrawRay(centerRotation, transform.position, Color.yellow, 1f);

    }
}
