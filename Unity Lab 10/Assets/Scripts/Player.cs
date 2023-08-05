using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsMoving => (Vector3.Distance(lastUpdatePosition, transform.position) > 0.01f);

    private Vector3 lastUpdatePosition;

    void Start()
    {
        lastUpdatePosition = transform.position = RandomPointHelper.RandomPointOnMesh(transform.position, 100) + Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        lastUpdatePosition = transform.position;
    }

}
