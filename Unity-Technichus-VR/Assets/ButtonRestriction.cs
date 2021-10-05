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
    //public GameObject canvas;

    void Start(){
        button.SetActive(false);
        //button1.SetActive(false);
        //button2.SetActive(false);
        //canvas.SetActive(true);
    }
    void Update()
    {
        if(image.enabled == true && image1.enabled == true && image2.enabled == true){
            enabler();
        }
    }
    public void enabler(){
        button.SetActive(true);
        //button1.SetActive(true);
        //button2.SetActive(true);
        //canvas.SetActive(false);
    }
}
