using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallRespawn : MonoBehaviour
{
    public Vector3 startPos = new Vector3();
    
    void Start()
    {
        
        startPos = transform.position;
    }

    
  void OnTriggerEnter(Collider enterer)
 {
 
     if (enterer.CompareTag("Wall"))
     {
        enterer.transform.position  = startPos;
     }
 
 }

}
