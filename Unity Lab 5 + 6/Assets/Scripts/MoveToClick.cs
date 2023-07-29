using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

public class MoveToClick : MonoBehaviour
{
    private NavMeshAgent agent;
    public Camera mainCamera;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (!hit.collider.CompareTag("Obstacle"))
                    agent.SetDestination(hit.point);
            }
        }
    }

}
