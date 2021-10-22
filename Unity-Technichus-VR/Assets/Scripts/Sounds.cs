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

    //Sound of the ball rolling on the floor
    public void rollOnFloorSound()
    {
        ballRolling.Play();
    }

    //Sound of the ball rolling in the gutter
    public void gutterSound()
    {
        ballRolling.Stop();
        gutter.Play();
    }

    //Sound of the ball hitting pins
    public void ballHitPinSound()
    {
        ballRolling.Stop();
        ballHitPin.Play();
    }

    //Sound of the ball falling in the pit
    public void backWallSound()
    {
        ballRolling.Stop();
        gutter.Stop();
        backWall.Play();
    }

    //Sound of ball respawning
    public void respawnSound()
    {
        respawn.Play();
    }
}
