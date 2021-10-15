using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource ballRolling;
    public AudioSource ballHit1Pin;
    public AudioSource ballHit4Pin;
    public AudioSource ballHit10Pin;


    // public void rollOnFloor()
    // {
    //     Debug.Log("TEST!!!!!!");
    //     ballRolling.Play();
    // }
    //Start is called before the first frame update
    //void Start()
    //{
    //     sounds = GetComponent<AudioSource>();
        
    // }

    // Update is called once per frame

    public void rollOnFloor()
    {
        ballRolling.Play();
    }
    public void ballHit1()
    {

    }

    public void ballHit10()
    {
        ballRolling.Stop();
        ballHit10Pin.Play();
    }

     /*void OnCollisionEnter(Collision collision) 
     {
        if(collision.gameObject.name == "bowlingFloor")
        {
            ballRolling.Play();
        }
        else if(collision.gameObject.name == "Pin")
        {
            ballRolling.Stop();
            ballHit10Pin.Play();
        }
        else if(collision.gameObject.name == "backWall")
        {
            ballRolling.Stop();
            ballHit10Pin.Stop();
        }
    }*/
}
