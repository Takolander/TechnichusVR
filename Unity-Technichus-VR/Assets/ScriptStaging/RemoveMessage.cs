using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMessage : MonoBehaviour
{
    public new GameObject gameObject;
    public new GameObject gameObject1;
    public new GameObject Canvas;
    //public new GameObject camera;
    //public FadeInFadeOut fader;
    public float Timer = 10.0f;

    // Update is called once per frame
    void Start(){
        gameObject1.SetActive(false);
        StartCoroutine(Wait());
    }

    //Wait for Timer seconds
    public IEnumerator Wait() {

        //Disable the canvas object
        if(gameObject.activeSelf == false){
            gameObject1.SetActive(true);
            yield return new WaitForSeconds(Timer);
            Canvas.SetActive(false);
        }

        //Disable only the first object in the canvas
        if(gameObject.activeSelf == true){
            yield return new WaitForSeconds(Timer);
            gameObject.SetActive(false);
            StartCoroutine(Wait());
        }
    }
}