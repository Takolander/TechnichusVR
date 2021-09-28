using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class BowlingBallRespawn : MonoBehaviour
{ 
    Vector3 respawnPos = new Vector3(1.598f,0.551f, 0.275f);
    float minimumSpeed = 0.1f;
    float speed = 0f;

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "backWall" || other.gameObject.name == "Plane"){
            Invoke("SpawnNext", 2f); 
        }
        /*if(other.gameObject.name == "Floor"){
            if(speed < minimumSpeed){
                Invoke("SpawnNext", 0f);
            }
        }*/
    }
       /*if (interactable != null && interactable.attachedToHand != null){
            if (interactable.attachedToHand = null){*/
    /*void Update(){
            //Vector3 startPos = new Vector3(x, y, z);
            speed = Vector3.Distance(respawnPos, transform.position) * 1f;
            respawnPos = transform.position;
            Debug.Log("Speed: " + speed.ToString("F2"));
    }*/
    
    void SpawnNext()
    {
        //GameObject newBox = Instantiate(gameObject);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gameObject.transform.position = respawnPos;
        //Debug.Log(gameObject.GetComponent<Rigidbody>().velocity);
        //Destroy(gameObject);
    }
}
