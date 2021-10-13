using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource ballRolling;
    public AudioSource ballHit1Pin;
    public AudioSource ballHit4Pin;
    public AudioSource ballHit10Pin;

    // Start is called before the first frame update
    // void Start()
    // {
    //     sounds = GetComponent<AudioSource>();
        
    // }

    // Update is called once per frame

    void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.name == "pin")
        {
            ballHit10Pin.Play();
        }
        
        else if(collision.gameObject.name == "bowlingFloor")
        {
            ballRolling.Play();
        }
    }
}
