using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class BowlingBallRespawn : MonoBehaviour
{ 
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "backWall"){
            Invoke("SpawnNext", 2f); 
        } 
    }
    void SpawnNext()
    {
        GameObject newBox = Instantiate(gameObject);
        newBox.transform.position = new Vector3(-0.02000046f, 0.125f, 1.609996f);
        Destroy(gameObject);
    }
}
