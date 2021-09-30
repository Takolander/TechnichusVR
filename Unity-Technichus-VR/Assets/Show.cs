using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject thisObject;
    public float Timer = 1.5f;

    void Start(){
        thisObject.SetActive(false);
    }

    // Update is called once per frame
    public IEnumerator Wait() {
        //Wait for 5 seconds
        yield return new WaitForSeconds(Timer);
        thisObject.SetActive(true);
        //gameObject.SetActive(false);
    }
    void Awake()
    {
        if(gameObject == null){
            StartCoroutine(Wait());
        }
        Debug.Log(gameObject);
    }
}
