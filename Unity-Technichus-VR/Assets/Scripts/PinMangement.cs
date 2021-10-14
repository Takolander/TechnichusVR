using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMangement : MonoBehaviour
{
    //Member variables
    private Pin[] pins;
    private Vector3[] positions;
    private Quaternion[] rotations;
    private int[] scores;
    public int numberOfThrows;
    private int numberOfFallenPins;
    public bool collision;
    private BowlingBall ball;
    private int finalScore;
    private int playedFrames;
    private int throwOne;
    private int scorePosition;

    //Intializes values
    public void Awake() {
        numberOfThrows = 0;
        numberOfFallenPins = 0;
        ball = GameObject.FindObjectOfType(typeof(BowlingBall)) as BowlingBall;
        pins = GetComponentsInChildren<Pin>();
        collision = false;
        scores = new int[12]; 
        finalScore = 0;
        playedFrames = 0;
        scorePosition = 0;
        savePosition(); 
    }

    //Called every frame and checks if a pin has fallen over or not
    void Update() {
        for (int i = 0; i < pins.Length; i++)
        {
            if((pins[i].transform.localEulerAngles.z < -45 || pins[i].transform.localEulerAngles.z > 45) && !collision && pins[i].gameObject.activeSelf) {
                collision = true;
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
    
    //Respawn function that resets pins or removes them depending on some criterias
    public void respawnPins() {
        //Loop thru pins and check if they have fallen over
        for (int i = 0; i < pins.Length; i++) {
            if((pins[i].transform.localEulerAngles.z < -45 || pins[i].transform.localEulerAngles.z > 45) && pins[i].gameObject.activeSelf) {
                pins[i].gameObject.SetActive(false);
                numberOfFallenPins++;
            }
        }
        if (numberOfThrows != 2) {
            throwOne = numberOfFallenPins;
            
        }
        //Check if the current round is over
        if (numberOfThrows == 2 || numberOfFallenPins == 10) {
            //Calculate the score
            calculateScore(throwOne, (numberOfFallenPins - throwOne));
            //Loop thru pins and respawn them
            for (int i = 0; i < pins.Length; i++) {
                pins[i].transform.position = positions[i];
                pins[i].transform.rotation = rotations[i];

                Rigidbody pinRigidbody = pins[i].GetComponent<Rigidbody>();
                pinRigidbody.velocity = Vector3.zero;
                pinRigidbody.angularVelocity = Vector3.zero;

                pins[i].gameObject.SetActive(true);
                
            }
            numberOfFallenPins = 0;
            numberOfThrows = 0;
            throwOne = 0;
        }
        collision = false; 
    }

    //Adds the score of the played frame to an array and at the end of the frames counts the final score
    public void calculateScore(int throwOne, int throwTwo) {
        scores[scorePosition] = throwOne;
        scores[scorePosition + 1] = throwTwo;
        scorePosition += 2;
            
        Debug.Log("Throw 1: " + throwOne);
        Debug.Log("Throw 2: " + throwTwo);
        playedFrames++;
        Debug.Log("Current frame: " + playedFrames);

        //Counts the final score when all three rounds have been palyed
        if (playedFrames == 4) {
            for (int i = 0; i < 8; i++) {
                Debug.Log("Värde på plats " + i + ": " + scores[i] + " och värde på plats " + (i+1) + ": " + scores[i+1]);
                //Strike
                if (scores[i] == 10) {
                    if (scores[i + 2] == 10) {
                        finalScore += (scores[i] + scores[i + 2] + scores[i + 4]);
                        i++;
                        Debug.Log("Strike");
                    }
                    else {
                        finalScore += (scores[i] + scores[i + 2] + scores[i + 3]);
                        i++;
                        Debug.Log("Strike");
                    }
                } //Spare
                else if (scores[i] + scores[i + 1] == 10) {
                    finalScore += (scores[i] + scores[i + 1] + scores[i + 2]);
                    Debug.Log("Spare");
                } //All other cases 
                else {
                    finalScore += scores[i] + scores[i + 1];
                    i++;
                    Debug.Log("Ingen Strike eller Spare");
                }
            }
            Debug.Log(finalScore);
        }
    }
}