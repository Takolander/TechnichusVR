using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    //Score is static so that the pins use the same variable
    public static int score = 0;
    public Vector3 respawnPos;

    //Get starting posision of the pin
    void Start() {
        respawnPos = gameObject.transform.position;
    }

    public void countScore() {
        Debug.Log("Score method called");
        //Checks if the pin has been nocked in the x or z rotation and adds to the score
        if (transform.rotation.x > 0.1 || transform.rotation.x < -0.1) {
            score++;
            Debug.Log("X rotation knoked down, Score: " + score);
        } else if (transform.rotation.z > 0.1 || transform.rotation.z < -0.1 ) {
            score++;
            Debug.Log("Z rotation knoked down, Score: " + score);
        }

        
    }

    public void respawn() {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        gameObject.transform.position = respawnPos;
    }
}
