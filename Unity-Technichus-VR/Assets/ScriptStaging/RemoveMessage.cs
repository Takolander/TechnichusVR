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
    public IEnumerator Wait() {

        //Wait for Timer seconds
        if(gameObject.activeSelf == false){
            gameObject1.SetActive(true);
            yield return new WaitForSeconds(Timer);
            Canvas.SetActive(false);
        }
        if(gameObject.activeSelf == true){
            yield return new WaitForSeconds(Timer);
            gameObject.SetActive(false);
            StartCoroutine(Wait());
        }
        //Destroy(gameObject);
    }
    /*void Update()
    {
        //adjust the value more for middle
        //Gets the cameras rotation x axel and then wait and disable the object
        if(camera.transform.rotation.x > 0.3){
            StartCoroutine(Wait());
        }
    }*/
}