using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMessage : MonoBehaviour
{
    public new GameObject gameObject;
    public new GameObject camera;
    //public FadeInFadeOut fader;
    public float Timer = 5.0f;

    // Update is called once per frame
    public IEnumerator Wait() {

        //Wait for Timer seconds
        yield return new WaitForSeconds(Timer);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
    void Update()
    {
        //adjust the value more for middle
        //Gets the cameras rotation x axel and then wait and disable the object
        if(camera.transform.rotation.x > 0.3){
            StartCoroutine(Wait());
        }
    }
}