using UnityEngine;
using UnityEngine.AI;

public class Player : BaseBehaviour
{
    private Vector3 lastUpdatePosition;
    private float waiting;

    public bool IsMoving => (waiting > 0) || (Vector3.Distance(lastUpdatePosition, transform.position) > 0.01f);

    private void Start()
    {
        lastUpdatePosition = transform.position = RandomPointHelper.RandomPointOnMesh(transform.position, 100) + Vector3.up;
        StopMoving();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.GameOver)
        {
            StopMoving();
        }
        else
        {
            if (waiting > 0)
            {
                waiting -= Time.deltaTime;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    Start();
                }
                else if (!IsMoving)
                {
                    if (Input.GetKey(KeyCode.Space))
                        waiting += 0.5f;
                    else
                    {
                        Vector3 move = Vector3.zero;

                        if (Input.GetKey(KeyCode.Keypad1))
                            move = new Vector3(-1, 0, -1);
                        else if (Input.GetKey(KeyCode.Keypad2))
                            move = new Vector3(0, 0, -1);
                        else if (Input.GetKey(KeyCode.Keypad3))
                            move = new Vector3(1, 0, -1);
                        else if (Input.GetKey(KeyCode.Keypad4))
                            move = new Vector3(-1, 0, 0);
                        else if (Input.GetKey(KeyCode.Keypad6))
                            move = new Vector3(1, 0, 0);
                        else if (Input.GetKey(KeyCode.Keypad7))
                            move = new Vector3(-1, 0, 1);
                        else if (Input.GetKey(KeyCode.Keypad8))
                            move = new Vector3(0, 0, 1);
                        else if (Input.GetKey(KeyCode.Keypad9))
                            move = new Vector3(1, 0, 1);

                        if (move != Vector3.zero)
                            agent.SetDestination(transform.position + move.normalized);
                    }
                }
            }
        }

    }

    private void FixedUpdate()
    {
        lastUpdatePosition = transform.position;
    }

    public void StopMoving() => agent.SetDestination(transform.position);
}
