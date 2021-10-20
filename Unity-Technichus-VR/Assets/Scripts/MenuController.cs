using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;


public class MenuController : MonoBehaviour
{
    public GameObject baseControllerGameObject;
    public GameObject menuControllerGameObject;
    public GameObject menuCanvas;

    public InputActionReference menuActivationReference;

    [Space]
    public UnityEvent onMenuActivate;
    public UnityEvent onMenuCancel;

    public void Start()
    {
        menuActivationReference.action.performed += MenuModeToogle;
    }

    private void MenuModeToogle(InputAction.CallbackContext obj) {
        if(!menuCanvas.activeSelf) {
            Debug.Log("Canvas is off, turning on");
            onMenuActivate.Invoke();
        } else {
            Debug.Log("Canvas is on, turning off");
            onMenuCancel.Invoke();
        }
    }
}
