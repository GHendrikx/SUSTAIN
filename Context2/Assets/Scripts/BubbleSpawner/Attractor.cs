using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    private GameObject destination;

    void Awake()
    {
        destination = GameObject.FindGameObjectWithTag("Destination");
        Debug.Log("Found");
    }

    // Update is called once per frame
    void Update()
    {
        float gravity = 5f;

        Vector3 heading = destination.transform.position - transform.position;
        float forceAmount = heading.magnitude;

        GetComponent<Rigidbody>().AddForce(heading.normalized * (forceAmount * gravity +1f)); 

        if(heading.magnitude < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
