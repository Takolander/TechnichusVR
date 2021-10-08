using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource sounds;
    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.name == "pin")
        {
            sounds.Play();
        }
    }
}
