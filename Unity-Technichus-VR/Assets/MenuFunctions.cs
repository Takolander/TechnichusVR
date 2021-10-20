using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class MenuFunctions : MonoBehaviour
{
    public MenuController menucon;

    public void ContinueGame () 
    {
        //Close Menu and continue bowlinggame where it pasued
        menucon.onMenuCancel.Invoke();
    }

    public void QuitGame () 
    {
        //Quit game and return to stagingroom
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void ResetGame () 
    {
        //Reset game, reload and start over bowlinggame
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
