using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForceMode : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float thrust = 100f;
    public ForceMode forceMode = ForceMode.Acceleration;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        rigidbody.AddForce(Vector3.right * thrust, forceMode);
    }

}
