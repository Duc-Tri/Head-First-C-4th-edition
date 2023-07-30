using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    private void OnMouseDrag()
    {
        transform.position += new Vector3(0, Input.GetAxis("Mouse Y"), 0);

        transform.position = new Vector3(transform.position.x,
            Mathf.Clamp(transform.position.y, 1f, 5f),
            transform.position.z);
    }
}
