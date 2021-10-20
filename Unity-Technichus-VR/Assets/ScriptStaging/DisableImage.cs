using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisableImage : MonoBehaviour
{
    private UnityEngine.UI.Image image ;

    //The image gets the component and execute the hider function
    private void Awake()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        Hider();
    }

    //Disable the image so its not shown
    public void Hider(){
        image.enabled = false;
    }
}
