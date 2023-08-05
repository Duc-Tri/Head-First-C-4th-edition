using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRandomPointNavMesh : MonoBehaviour
{
    void Update()
    {
        Vector3 randomPoint = RandomPointHelper.RandomPointOnMesh(Vector3.zero, 100);
        Debug.DrawRay(randomPoint, Vector3.up, Color.yellow, 1);
    }
}
