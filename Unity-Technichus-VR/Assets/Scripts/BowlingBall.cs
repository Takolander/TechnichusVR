using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BowlingBall : MonoBehaviour
{ 
    //The respawn position of the ball
    Vector3 respawnPos = new Vector3(1.598f,0.551f, 0.275f);

    //Need to make sure that the wait funtion dosen't run multible times
    public bool collided = false;

    //Checks for collison with other objects
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
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gameObject.transform.position = respawnPos;
    }

    public IEnumerator Wait() {
        //Wait for 5 seconds
        yield return new WaitForSeconds(5.0f);

        GameObject[] pins = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject pin in pins) {
            pin.GetComponent<BowlingPin>().tallyScore();
        }
    }
}
