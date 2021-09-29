using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    public static int score = 0;

    public void tallyScore() {
        if (transform.rotation.x < 1 && transform.rotation.z < 1) {
            //Dooes nothing pin is standing up 
        } else {
            score++;
            Debug.Log(score);
        }
    }
}
