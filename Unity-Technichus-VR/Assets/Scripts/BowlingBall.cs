using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BowlingBall : MonoBehaviour
{ 
    //The respawn position of the ball
    Vector3 respawnPos = new Vector3(1.316f, 0.308f, 3.484f);
    Vector3 respawnForce = new Vector3(0f, 1f, -1f);

    //Need to make sure that the wait funtion dosen't run multible times
    public bool collided = false;

    //
    void Start() {
        respawnForce.Normalize();
    }

    //Checks for collison with other objects
    void OnCollisionEnter(Collision other) {
        //Checks if the bowlingball has colided with the backwall or the floor and calls respawn function
        if(other.gameObject.name == "backWall" || other.gameObject.name == "Plane") {
            Invoke("respawnBowlingBall", 2f); 
        }
        else if (other.gameObject.tag == "pin" && !collided) {
            collided = true;
            StartCoroutine(Wait());
        }
    }
    
    //Respawn function that resets the transform of the bowlingball and it's velocity
    void respawnBowlingBall() {
        collided = false;

        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        gameObject.transform.position = respawnPos;

        //Gives the ball a velocity on spawn to come out of the ball machine
        gameObject.GetComponent<Rigidbody>().AddForce(respawnForce * 1500);
    }

    public IEnumerator Wait() {
        //Wait for 5 seconds
        yield return new WaitForSeconds(5.0f);

        GameObject[] pins = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject pin in pins) {
            pin.GetComponent<BowlingPin>().countScore();
        }
    }
}
