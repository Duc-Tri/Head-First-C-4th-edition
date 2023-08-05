using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

internal class RandomPointHelper
{
    public static Vector3 RandomPointOnMesh(Vector3 startingPoint, int numberOfSteps)
    {
        Vector3 randomPointOnMesh = startingPoint;
        for (int i = 0; i < numberOfSteps; i++)
        {
            randomPointOnMesh = SampleRandomMeshPosition(randomPointOnMesh);
        }

        return randomPointOnMesh;
    }

    public static Vector3 SampleRandomMeshPosition(Vector3 startingPoint)
    {
        Vector3 randomPoint = startingPoint + Random.insideUnitSphere * 6f;
        NavMeshHit hit;
        Vector3 newPoint = startingPoint;

        if (NavMesh.SamplePosition(randomPoint, out hit, 6f, NavMesh.AllAreas))
        {
            newPoint = hit.position;
        }

        return newPoint;
    }

}

