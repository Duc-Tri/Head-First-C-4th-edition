using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBall : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 forceAdded;
    public float Multiplier = 100f;
    public float MaxMultiplier = 3000f;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        InvokeRepeating("MoveMe", 1f, 1.5f);
    }

    private void MoveMe()
    {
        forceAdded = new Vector3(Multiplier - Random.value * Multiplier * 2,
            0,
            Multiplier - Random.value * Multiplier * 2);

        rigidbody.AddForce(forceAdded);
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

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(forceAdded);
    }

    private void MoveMe2()
    {
        // remove force added last time
        rigidbody.velocity = Vector3.zero;
        // add force in a random direction
        forceAdded = Random.insideUnitSphere * 500f;
        rigidbody.AddForce(forceAdded);

        // the ball will suddenly change direction
    }

    void Update()
    {
        Debug.DrawRay(transform.position, forceAdded, Color.white);
    }


}
