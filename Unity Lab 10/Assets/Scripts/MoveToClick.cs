using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToClick : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameController gameController;
    private Camera mainCamera;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        gameController = Camera.main.GetComponent<GameController>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (!gameController.GameOver && Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500))
            {
                Debug.Log("HIT: " + hit.collider.gameObject.tag);

                if (!hit.collider.CompareTag("Obstacle"))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }
}
