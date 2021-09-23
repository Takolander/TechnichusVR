using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
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
    }
}
