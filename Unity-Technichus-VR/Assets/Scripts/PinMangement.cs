using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMangement : MonoBehaviour
{
    //Arrays for child pins
    private Pin[] pins;
    private Vector3[] positions;
    private Quaternion[] rotations;
    public int numberOfThrows = 0;
    private int numberOfFallenPins;
    public bool collision;
    //Ny kod------------------
    private BowlingBall ball;
    //--------------------
    public void Awake() {
        numberOfThrows = 0;
        numberOfFallenPins = 0;
        /* Ny kod --> */ ball = GameObject.FindObjectOfType(typeof(BowlingBall)) as BowlingBall;
        pins = GetComponentsInChildren<Pin>();
        collision = false;
        savePosition(); 
        
    }

    void Update() {
        for (int i = 0; i < pins.Length; i++)
        {
            if((pins[i].transform.localEulerAngles.z < -45 || pins[i].transform.localEulerAngles.z > 45) && !collision && pins[i].gameObject.activeSelf) {
                collision = true;
                Invoke("respawnPins", 3.0f);
            }/*Ny kod -->*/ else if(numberOfThrows == 2 && ball.needsToRespawn) {
                
                Invoke("respawnPins", 3.0f);
            }
        }    
    }

    //Get starting posisions and roatation for each pin
    public void savePosition() {
        positions = new Vector3[pins.Length];
        rotations = new Quaternion[pins.Length];

        for (int i = 0; i < pins.Length; i++) {
            positions[i] = pins[i].transform.position;
            rotations[i] = pins[i].transform.rotation;
        }
    }
    
    public void respawnPins() {
        for (int i = 0; i < pins.Length; i++) {
            if((pins[i].transform.localEulerAngles.z < -45 || pins[i].transform.localEulerAngles.z > 45) && pins[i].gameObject.activeSelf) {
                pins[i].standing = false;
                pins[i].gameObject.SetActive(false);
                numberOfFallenPins++;
            }
        }
        Debug.Log("Ammount of pins hit: " + numberOfFallenPins);
        if (numberOfThrows == 2 || numberOfFallenPins == 10) {
            Debug.Log("Number of throws: " + numberOfThrows);
            Debug.Log("Number of fallenPins: " + numberOfFallenPins);
            Debug.Log("Respawning...");
            for (int i = 0; i < pins.Length; i++) {
                pins[i].transform.position = positions[i];
                pins[i].transform.rotation = rotations[i];

                Rigidbody pinRigidbody = pins[i].GetComponent<Rigidbody>();
                pinRigidbody.velocity = Vector3.zero;
                pinRigidbody.angularVelocity = Vector3.zero;

                pins[i].standing = true;
                pins[i].gameObject.SetActive(true);
                
            }
            numberOfFallenPins = 0;
            numberOfThrows = 0;
        }
        collision = false; 
    }
}