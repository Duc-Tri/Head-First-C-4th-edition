using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    private static Player player = null;

    private static GameController gameController = null;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        if (gameController == null)
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

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

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"{name} collided with {other.tag}");

        if (other.CompareTag("Player"))
            gameController.PlayerDied();
        else if (other.CompareTag("Robot"))
        {
        }

    }

}
