using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public GameObject button;
    public UnityEngine.UI.Image image ;
    public UnityEngine.UI.Image image1 ;
    public UnityEngine.UI.Image image2 ;
    public UnityEngine.UI.Image image3 ;
    //public GameObject canvas;

    //Sets the button inactive so it's not shown at the start of scene
    void Start(){
        button.SetActive(false);
        //button1.SetActive(false);
        //button2.SetActive(false);
        //canvas.SetActive(true);
    }

    //Checks if the image on the warnings have been enabled and then calls for function
    void Update()
    {
        if(image.enabled == true && image1.enabled == true && image2.enabled == true && image3.enabled == true){
            enabler(); 
        }
    }

    //Show the button to the space to be able to press on
    public void enabler(){
        button.SetActive(true);
        //button1.SetActive(true);
        //button2.SetActive(true);
        //canvas.SetActive(false);
    }
}
