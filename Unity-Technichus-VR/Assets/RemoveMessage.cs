using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject gameObject;
    public float Timer = 5.0f;
    // Update is called once per frame
    public IEnumerator Wait() {
        //Wait for 5 seconds
        yield return new WaitForSeconds(Timer);
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
    void Update()
    {
        if(transform.rotation.x > -1){
            StartCoroutine(Wait());
        }
    }
}