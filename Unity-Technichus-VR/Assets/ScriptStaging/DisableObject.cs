using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisableObject : MonoBehaviour
{
    private Canvas canvas ;

    //The image gets the component and execute the hider function
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        Hider();
    }

    //Disable the image so its not shown
    public void Hider(){
        canvas.enabled = false;
    }
}
