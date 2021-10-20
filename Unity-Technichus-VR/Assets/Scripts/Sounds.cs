using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource ballRolling;
    public AudioSource gutter;
    public AudioSource backWall;
    public AudioSource respawn;
    public AudioSource ballHitPin;


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

    public void rollOnFloorSound()
    {
        ballRolling.Play();
    }
    public void gutterSound()
    {
        ballRolling.Stop();
        gutter.Play();
    }

    public void ballHit10Sound()
    {
        ballRolling.Stop();
        ballHitPin.Play();
    }

    public void backWallSound()
    {
        ballRolling.Stop();
        gutter.Stop();
        backWall.Play();
    }

    public void respawnSound()
    {
        respawn.Play();
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
