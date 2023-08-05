using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameController gameController;
    public bool IsMoving => (Vector3.Distance(lastUpdatePosition, transform.position) > 0.01f);

    private Vector3 lastUpdatePosition;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        lastUpdatePosition = transform.position = RandomPointHelper.RandomPointOnMesh(transform.position, 100) + Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.GameOver)
        {
            StopMoving();
        }
    }

    private void FixedUpdate()
    {
        lastUpdatePosition = transform.position;
    }

    public void StopMoving() => agent.SetDestination(transform.position);
}
