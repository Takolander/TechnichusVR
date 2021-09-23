using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisableImage : MonoBehaviour
{
    private UnityEngine.UI.Image image ;
    // Start is called before the first frame update
    private void Awake()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        Hider();
    }
    public void Hider(){
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
