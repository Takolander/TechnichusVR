using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPhysics : MonoBehaviour
{

    public GameObject bowlingBall;
    public float ballDistance = 2.5f;
    public float ballThrowingForce = 200f;
    public bool holding = true;
    void start()
    {
        if (holding == true)
        {
            bowlingBall.transform.position = transform.position + transform.forward * ballDistance;

            if (Input.GetKeyDown("space"))
            {
                holding = false;
                bowlingBall.GetComponent<Rigidbody>().useGravity = true;
                bowlingBall.GetComponent<Rigidbody>().AddForce(transform.forward * ballThrowingForce);
            }
        }
    }
    public void OnTouchFloor()
    {
        Destroy (gameObject);
    }

   /* private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.tag == "floor")
        {
            pin.OnTouchFloor();
        }
    }*/
}