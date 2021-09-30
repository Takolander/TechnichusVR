using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMessage : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject camera;
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
        //adjust the value more for middle
        if(camera.transform.rotation.x > 0.3){
            StartCoroutine(Wait());
            
        }
    }
}