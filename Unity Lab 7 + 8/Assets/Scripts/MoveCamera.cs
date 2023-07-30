using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    private float angle = 3f;

    [SerializeField]
    private float zoomSpeed = 0.25f;

    void Start()
    {
        transform.position = new Vector3(0, 29, -17);
        transform.rotation = Quaternion.identity;
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.LookAt(player); // always

        Vector3 rotation = Vector3.zero;

        if (Input.GetKeyUp(KeyCode.LeftArrow))
            rotation = Vector3.up;

        if (Input.GetKeyUp(KeyCode.RightArrow))
            rotation = Vector3.down;

        if (Input.GetKeyUp(KeyCode.UpArrow))
            rotation = Vector3.right;

        if (Input.GetKeyUp(KeyCode.DownArrow))
            rotation = Vector3.left;

        if (rotation != Vector3.zero)
        {
            transform.RotateAround(player.position, rotation, angle);
        }

        float scrollWheelValue;
        if ((scrollWheelValue = Input.GetAxis("Mouse ScrollWheel")) != 0)
            transform.position *= (1f + scrollWheelValue * zoomSpeed);
    }
}
