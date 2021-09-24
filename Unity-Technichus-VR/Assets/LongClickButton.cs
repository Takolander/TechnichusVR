using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;

public class LongClickButton : MonoBehaviour
{
    void Update(){
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);

        foreach(var item in devices){
            Debug.Log(item.name + item.characteristics);
        }
    }
    /*private bool pointerDown;
    private float pointerDownTimer;
    private float rip;
    private float requiredHoldTime = 3;

    public UnityEvent onLongClick;

    private Image fillImage;
    void start(){
        fillImage = fillImage.GetComponent<Image>();
    }
    public void OnPointerDown(PointerEventData eventData){
        pointerDown = true;
        Debug.Log("OnPointerDown");
    }
    public void OnPointerUp(PointerEventData eventData){
        Reset();
        Debug.Log("OnPointerUp");
    }
    // Update is called once per frame
    void Update()
    {
        if(pointerDown){
            pointerDownTimer += Time.deltaTime;
            if(pointerDownTimer >= requiredHoldTime){
                if(onLongClick != null){
                    onLongClick.Invoke();
                }
                Reset();
            }
            rip = pointerDownTimer / requiredHoldTime;
        }
    }
    private void Reset(){
        pointerDown = false;
        pointerDownTimer = 0;
        rip = pointerDownTimer / requiredHoldTime;
    }*/
}
