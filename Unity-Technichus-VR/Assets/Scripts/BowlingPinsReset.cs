using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPinsReset : MonoBehaviour
{
    //Spawning position
    Vector3 respawnPos = new Vector3(0f, 0.34f, 14.675f);

    void Update() {
        updateScore();    
    }

    void updateScore() {
        //Debug.Log("X-Value: " + transform.rotation.x);
        //Debug.Log("Z-Value: " + transform.rotation.z);
        if (transform.rotation.x > 0.1) {
            Debug.Log(transform.rotation.x);
            Destroy(gameObject, 2f);
        }
        else if(transform.rotation.z > 0.1){
            Debug.Log(transform.rotation.z);
            Destroy(gameObject, 2f);
        }
    }

    /*
    //Checks for collision between pins and ball
    void OnCollisionEnter(Collision other){
        Debug.Log("Ball colided with pins");
        if (other.gameObject.name == "BowlingBall")
        {
            Invoke("respawn", 5f);
        }
    }

    //Respawns pins at starting location
    void respawn(){
        GameObject newBox = Instantiate(gameObject);
        newBox.transform.position = respawnPos;
        Destroy(gameObject);
    }*/
}
