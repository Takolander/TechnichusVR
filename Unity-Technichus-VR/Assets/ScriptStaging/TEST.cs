using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TEST : MonoBehaviour
{
    private GameObject canvas;

    //The image gets the component and execute the hider function
    private void Start()
    {
        canvas = GetComponent<GameObject>();
        Hider();
        StartCoroutine(Shower());
    }

    //Disable the image so its not shown
    public void Hider(){
        canvas.SetActive(false);
    }
    IEnumerator Shower(){
        yield return new WaitForSeconds(10);
        canvas.SetActive(true);
    }
}
