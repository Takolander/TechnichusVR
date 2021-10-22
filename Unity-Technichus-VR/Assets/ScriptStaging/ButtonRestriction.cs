using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonRestriction : MonoBehaviour
{
    public GameObject button;
    public UnityEngine.UI.Image image ;
    public UnityEngine.UI.Image image1 ;
    public UnityEngine.UI.Image image2 ;

    //Sets the button inactive so it's not shown at the start of scene
    void Start(){
        button.SetActive(false);
    }

    //Checks if the image on the warnings have been enabled and then calls for function
    void Update()
    {
        if(image.enabled == true && image1.enabled == true && image2.enabled == true){
            enabler();
        }
    }

    //Show the button to the space to be able to press on
    public void enabler(){
        button.SetActive(true);
    }
}
