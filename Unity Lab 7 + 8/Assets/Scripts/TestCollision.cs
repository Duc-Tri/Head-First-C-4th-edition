using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        // time in seconds since the game started
        Debug.Log($"{this.name} collided with {collision.gameObject.name} at {Time.time}");

    }
}
