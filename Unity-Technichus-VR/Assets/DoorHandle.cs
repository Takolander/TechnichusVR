using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  

public class DoorHandle : MonoBehaviour {  
    public string sceneName;
    void OnTriggerEnter(Collider other) {
        //Checks if the bowlingball has colided with the backwall or the floor and calls respawn function
        if(other.gameObject.name == "door_handle") {
            LoadScene(sceneName);
        }
    }
    //Load an Scene
    public void LoadScene(string sceneName) {  
        //SceneManager.LoadScene(sceneName);  
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }  
}  
