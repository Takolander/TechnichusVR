using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;


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
            if(SceneManager.GetActiveScene().name == "Staging") {
                return;
            } else {
                Debug.Log("Canvas is off, turning on");
                onMenuActivate.Invoke();
            }
        } else {
            Debug.Log("Canvas is on, turning off");
            onMenuCancel.Invoke();
        }
    }
}
