using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour
{
    public new GameObject gameObject;
    public GameObject thisObject;
    public float timer = 1.5f;

    void Start(){
        //Disable object
        thisObject.SetActive(false);
    }
    //Wait for timer's seconds
    public IEnumerator Wait() {
        yield return new WaitForSeconds(timer);
        thisObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject == null){
            StartCoroutine(Wait());
            enabled = false;
        }
    }
}
