using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BowlingBall : MonoBehaviour
{ 

    //Member variables
    private Vector3 respawnPos = new Vector3(13.2819996f, 0.231000006f, 36.0979996f);
    private Vector3 respawnForce = new Vector3(0f, 1f, 1f);

    private PinMangement pinManager;
    public bool needsToRespawn;
    public bool hasHitPin;
    private Sounds sound;

    //Initializes values
    public void Awake() {
        respawnForce.Normalize();
        needsToRespawn = false;
        hasHitPin = false;
    }

    void FixedUpdate() {
        GetComponent<Rigidbody>().AddForce(Vector3.down * 5f * GetComponent<Rigidbody>().mass);
    }
    //Gets refernce to the pinManager script
    public void Start() {
        pinManager = GameObject.FindObjectOfType(typeof(PinMangement)) as PinMangement;
        sound = GameObject.FindObjectOfType(typeof(Sounds)) as Sounds;

    }

    //Checks for collison with other objects
    public void OnCollisionEnter(Collision other) {
        //Gets name of the object we colided with
        var name = other.gameObject.name;

        switch (name)
        {
            //Collision with anything but the actual playing bowlingFloor
            //case "renna":
            
            case "backFloor":
            case "leftFloorAndTracks":
            case "rightFloorAndTracks":
                Debug.Log("Bollen har kastats utanför bannan");
                Invoke("respawnBowlingBall", 2f);
                break;
            //Collision with the back wall at the end of the court
            case "backWall":
                
                Debug.Log("Du har nått backwall");
                sound.backWallSound();
                //Check if we diden't hit a pin on the way
                if (!hasHitPin)
                {
                    //Have we made two throws?
                    if (pinManager.numberOfThrows == 2)
                    {
                        pinManager.Invoke("respawnPins", 2f);
                    }
                    Invoke("respawnBowlingBall", 2f);
                }
                break;
            //Collision with a pin
            case "Pin":
                //Check if we have hit a pin before to not call this method over and over
                if (!hasHitPin)
                {
                    sound.ballHit10Sound();
                    hasHitPin = true;
                    Invoke("respawnBowlingBall", 2f);
                }
                break;
            //Collision with the playable bowlingFloor
            case "bowlingFloor":
            
                Debug.Log("Du har tr�ffat bannan");
                //Makes it so the ball is in a state that it needs to respawn and counts the throw
                if (!needsToRespawn)
                {
                    sound.rollOnFloorSound();
                    Debug.Log("R�knas som ett giltigt kast");
                    needsToRespawn = true;
                    pinManager.numberOfThrows++;
                }
                break;
            default:
                break;
        }
    }
     
    //Respawn function that resets the transform of the bowlingball and it's velocity. It also adds force to the ball when it respawns to roll out of the machine
    public void respawnBowlingBall() {
        gameObject.transform.position = respawnPos;

        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        
        gameObject.GetComponent<Rigidbody>().AddForce(respawnForce * 1400);
        needsToRespawn = false;
        hasHitPin = false;
    }
}
