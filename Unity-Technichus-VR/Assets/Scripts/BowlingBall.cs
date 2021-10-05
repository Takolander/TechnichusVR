using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BowlingBall : MonoBehaviour
{ 
    //Member variables
    private Vector3 respawnPos = new Vector3(1.316f, 0.308f, 3.484f);
    private Vector3 respawnForce = new Vector3(0f, 1f, -1f);
    private PinMangement pinManager;
    public bool needsToRespawn;
    public bool hasHitPin;

    //Initializes values
    public void Awake() {
        respawnForce.Normalize();
        needsToRespawn = false;
        hasHitPin = false;
    }

    //Gets refernce to the pinManager script
    public void Start() {
        pinManager = GameObject.FindObjectOfType(typeof(PinMangement)) as PinMangement;
    }

    //Checks for collison with other objects
    public void OnCollisionEnter(Collision other) {
        //Checks if the bowlingball has colided with the backwall or the floor and calls respawn function
        if(other.gameObject.name == "backWall" || other.gameObject.name == "Plane" && !hasHitPin) {
            Invoke("respawnBowlingBall", 2f); 
        } //Checks if the ball has hit the floor and is used to count amount of throws  
        else if (other.gameObject.name == "bowlingFloor" && !needsToRespawn) {
            Debug.Log("Collision with bowlingFloor");
            needsToRespawn = true;
            pinManager.numberOfThrows++;
        } //Checks if we have colided with a pin and calls the respawn function 
        else if(other.gameObject.name == "pin" && needsToRespawn){
            Debug.Log("Inne i nya funkationen");
            hasHitPin = true;
            Invoke("respawnBowlingBall", 2f);
        }
    }
     
    //Respawn function that resets the transform of the bowlingball and it's velocity. It also adds force to the ball when it respawns to roll out of the machine
    public void respawnBowlingBall() {
        gameObject.transform.position = respawnPos;

        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        
        gameObject.GetComponent<Rigidbody>().AddForce(respawnForce * 1500);
        needsToRespawn = false;
        hasHitPin = false;
    }
}