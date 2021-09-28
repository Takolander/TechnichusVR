using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class BowlingBallRespawn : MonoBehaviour
{ 
    float x = -0.02000046f;
    float y = 0.125f;
    float z = 1.609996f;
    float minimumSpeed = 0.5f;
    
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "backWall" || other.gameObject.name == "Plane"){
            Invoke("SpawnNext", 2f); 
        }
    }
       /*if (interactable != null && interactable.attachedToHand != null){
            if (interactable.attachedToHand = null){*/
    void FixedUpdate(){
            Vector3 startPos = new Vector3(x, y, z);
            var speed = Vector3.Distance(startPos, transform.position) * 100f;
            startPos = transform.position;
            Debug.Log("Speed: " + speed.ToString("F2"));

            if(speed < minimumSpeed){
                Invoke("SpawnNext", 2f);
            }
    }
    
    void SpawnNext()
    {
        GameObject newBox = Instantiate(gameObject);
        newBox.transform.position = new Vector3(x, y, z);
        Destroy(gameObject);
    }
}
