using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Robot : BaseBehaviour
{
    private static Player player = null;

    private bool alive = true;

    protected override void Awake()
    {
        base.Awake();
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (alive && !gameController.GameOver && player.IsMoving)
            agent.SetDestination(player.transform.position);
        else
            agent.SetDestination(transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"{name} collided with {other.tag}");

        if (alive)
        {
            if (other.CompareTag("Player"))
                gameController.PlayerDied();
            else if (other.CompareTag("Robot"))
            {
                Renderer renderer = gameObject.GetComponent<Renderer>();
                renderer.material.color = Color.black;

                alive = false;
                gameController.RobotDied();
            }
        }
    }

}
