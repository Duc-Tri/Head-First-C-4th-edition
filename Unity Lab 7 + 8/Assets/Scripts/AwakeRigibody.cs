using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeRigibody : MonoBehaviour
{
    Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Sleeping: {rigidBody.IsSleeping()} Time: {Time.time:0.00}");
    }

    private void OnMouseDown()
    {
        rigidBody.WakeUp();
    }
}
