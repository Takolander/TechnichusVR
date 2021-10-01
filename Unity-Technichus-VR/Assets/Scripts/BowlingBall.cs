using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BowlingBall : MonoBehaviour
{ 
    //The respawn position of the ball
    private Vector3 respawnPos = new Vector3(1.316f, 0.308f, 3.484f);
    private Vector3 respawnForce = new Vector3(0f, 1f, -1f);
    private PinMangement pinManager;
    public bool needsToRespawn; //Gjorde den public för att komma åt den i pinmanegment

    public void Awake() {
        respawnForce.Normalize();
        needsToRespawn = false;
    }

    public void Start() {
        pinManager = GameObject.FindObjectOfType(typeof(PinMangement)) as PinMangement;
    }

    //Checks for collison with other objects
    public void OnCollisionEnter(Collision other) {
        //Checks if the bowlingball has colided with the backwall or the floor and calls respawn function
        if(other.gameObject.name == "backWall" || other.gameObject.name == "Plane") {
            Invoke("respawnBowlingBall", 2f); 
        } else if (other.gameObject.name == "bowlingFloor" && !needsToRespawn) {
            Debug.Log("Collision with bowlingFloor");
            needsToRespawn = true;
            pinManager.numberOfThrows++;
        }
    }
    
    //Respawn function that resets the transform of the bowlingball and it's velocity
    public void respawnBowlingBall() {
        needsToRespawn = false;

        gameObject.transform.position = respawnPos;

        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        
        gameObject.GetComponent<Rigidbody>().AddForce(respawnForce * 1500);
    }
}
