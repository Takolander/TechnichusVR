using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    //Score is static so that the pins use the same variable
    public static int score = 0;
    public float timer = 5.0f;
    public Vector3 respawnPos;
    public Quaternion respawnRotation;

    GameObject ball;

    public bool standing = true;

    //Get starting posision of the pin
    void Start() {
        respawnPos = transform.position;
        respawnRotation = transform.rotation;
        ball = GameObject.Find("BowlingBall");
    }

    void Update() {
        if((gameObject.transform.localEulerAngles.z < -45 || gameObject.transform.localEulerAngles.z > 45) && standing){
            standing = false;
            StartCoroutine(Wait()); 
        }
    }

    public IEnumerator Wait(){
        Debug.Log("Wait called");
        yield return new WaitForSeconds(timer);
        ball.GetComponent<BowlingBall>().respawnBowlingBall();
        yield return new WaitForSeconds(1.0f);
        respawn();
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
        Debug.Log("Respawn called");
        gameObject.transform.rotation = respawnRotation;
        gameObject.transform.position = respawnPos;

        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        standing = true;
    }
}
