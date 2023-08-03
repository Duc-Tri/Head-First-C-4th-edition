using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static GameObject floor;
    private static Vector3 floorCenter;
    private static float minX, maxX, maxZ, minZ;

    public static int minStartHeight = 20;
    public static int maxStartHeight = 30;

    private Vector3 startingPosition;
    private static float halfSizeX, halfSizeZ;

    private void Awake()
    {
        if (floor == null)
        {
            floor = GameObject.FindGameObjectWithTag("Floor");

            Bounds floorBounds = floor.GetComponent<Renderer>().bounds;
            //floor.GetComponent<Bounds>();
            floorCenter = floorBounds.center;
            halfSizeX = floorBounds.size.x / 2f;
            halfSizeZ = floorBounds.size.z / 2f;
            minX = floorCenter.x - floorBounds.size.x / 2f + 0.5f;
            maxX = floorCenter.x + floorBounds.size.x / 2f - 0.5f;
            minZ = floorCenter.z - floorBounds.size.z / 2f + 0.5f;
            maxZ = floorCenter.z + floorBounds.size.z / 2f - 0.5f;

            Debug.Log("floorBounds = " + floorBounds);
            Debug.Log("floorBounds.size = " + floorBounds.size);
            Debug.Log("minX = " + minX);
            Debug.Log("maxZ = " + maxZ);
        }
    }

    private void Start()
    {
        startingPosition = transform.position = RandomPositionOverFLoor();
    }

    Vector3 RandomPositionOverFLoor()
    {
        return new Vector3(
            Random.value * 2f * halfSizeX - halfSizeX + floorCenter.x,
            //Random.Range(minX, maxX),
            Random.Range(minStartHeight, maxStartHeight),
            Random.value * 2f * halfSizeZ - halfSizeZ + floorCenter.z
            //Random.Range(minZ, maxZ)
            );
    }

    void Update()
    {
        Debug.DrawLine(transform.position, startingPosition, Color.yellow);
    }
}
