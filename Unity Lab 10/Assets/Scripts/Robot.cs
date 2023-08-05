using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    private static Player player = null;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Start()
    {
        transform.position = RandomPointHelper.RandomPointOnMesh(transform.position, 100) + Vector3.up;
    }

    void Update()
    {
        agent.SetDestination(player.IsMoving ?
            player.transform.position :
            transform.position);
    }

}
