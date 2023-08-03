using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    LayerMask maskFloor;

    [SerializeField]
    float multiplierForce = 100f;

    Camera mainCamera;
    Rigidbody rigidBody;
    private bool clicking;
    private GameController gameController;
    Vector3 startingPosition;
    bool HitTarget;

    private void Start()
    {
        startingPosition = transform.position;
        rigidBody = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        gameController = GameController.Instance;
        clicking = false;
    }

    void Update()
    {
        if (!gameController.GameOver)
        {
            HitBallMechanic();
            OutOfBoundsCheck();
        }
    }

    private void OutOfBoundsCheck()
    {
        if (transform.position.y < -5)
        {
            transform.position = startingPosition;
            //gameController.PlayerOutOfBounds();
            rigidBody.velocity = rigidBody.angularVelocity = Vector3.zero;

            if (!HitTarget) gameController.BallLost();
        }
    }

    private void HitBallMechanic()
    {
        if (!clicking && Input.GetMouseButton(0))
        {
            HitTarget = false;
            clicking = true;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.CompareTag("Player"))
                    rigidBody.AddForce(ray.direction * hit.distance * multiplierForce);
            }
        }
        else if (clicking && Input.GetMouseButtonUp(0))
        {
            clicking = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Target"))
            HitTarget = true;
    }

    private void HitFloorMechanic()
    {
        Ray r = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit, 1000, maskFloor))
        {
            Vector3 force = (hit.point - transform.position).normalized;
            rigidBody.AddForce(force * multiplierForce);
        }
    }

}
