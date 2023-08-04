using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBall : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private Vector3 forceAdded;
    public float Multiplier = 100f;
    public float MaxMultiplier = 3000f;

    private GameController gameController;

    [SerializeField]
    private AudioSource audioCollision2Balls;

    void Awake()
    {
    }

    private void Start()
    {
        audioCollision2Balls = GetComponent<AudioSource>();

        rigidbody = GetComponent<Rigidbody>();
        gameController = Camera.main.GetComponent<GameController>();
        if (gameController == null)
            gameController = GameController.Instance;

        InvokeRepeating("MoveMe", 1f, 1.5f);
    }

    private void MoveMe()
    {
        forceAdded = new Vector3(Multiplier - Random.value * Multiplier * 2,
            0,
            Multiplier - Random.value * Multiplier * 2);

        GetComponent<Rigidbody>().AddForce(forceAdded);
        Multiplier += 100f;
        if (Multiplier > MaxMultiplier)
            Destroy(gameObject);
    }

    private void MoveMe3()
    {
        if (forceAdded == Vector3.left * 500f)
            forceAdded = Vector3.forward * 500f;
        else if (forceAdded == Vector3.forward * 500f)
            forceAdded = Vector3.right * 500f;
        else if (forceAdded == Vector3.right * 500f)
            forceAdded = Vector3.back * 500f;
        else
            forceAdded = Vector3.left * 500f;

        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().AddForce(forceAdded);
    }

    private void MoveMe2()
    {
        // remove force added last time
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        // add force in a random direction
        forceAdded = Random.insideUnitSphere * 500f;
        GetComponent<Rigidbody>().AddForce(forceAdded);

        // the ball will suddenly change direction
    }

    void Update()
    {
        Debug.DrawRay(transform.position, forceAdded, Color.white);

        if (gameController.GameOver)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameController.CollideWithBall();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ball"))
        {
            audioCollision2Balls.Play();
        }
    }

}
