using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BowlingBall : MonoBehaviour
{ 
    //Member variables
    private Vector3 respawnPos = new Vector3(13.178f, 0.345f, 38.423f);
    private Vector3 respawnForce = new Vector3(0f, 1f, 1f);
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
        if(other.gameObject.name == "BRockRoom") {
            if(needsToRespawn){
                return;
            }
            Debug.Log("Respawnat på BRockRoom");
            Invoke("respawnBowlingBall", 2f); 
        } //Checks if the ball has hit the floor and is used to count amount of throws  
        else if(other.gameObject.name == "backWall" && !hasHitPin){
            if(pinManager.numberOfThrows == 2){
            pinManager.Invoke("respawnPins", 2f);
            Invoke("respawnBowlingBall", 2f);
            } else{
                Invoke("respawnBowlingBall", 2f);
            }
            
            //pinManager.numberOfThrows++;
        }
        else if (other.gameObject.name == "bowlingFloor" && !needsToRespawn) {
            needsToRespawn = true;
            pinManager.numberOfThrows++;
        } //Checks if we have colided with a pin and calls the respawn function 
        else if(other.gameObject.name == "Pin" && needsToRespawn && !hasHitPin){
            hasHitPin = true;
            Debug.Log("Träffat pin och behöver respawnas");
            Invoke("respawnBowlingBall", 2f);
        }
        /*else if (pinManager.numberOfThrows == 2 && other.gameObject.name == "backWall" && !hasHitPin) {
            Debug.Log("Inne i nya else if satsen");
            pinManager.Invoke("respawnPins", 3f);
        }*/
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
