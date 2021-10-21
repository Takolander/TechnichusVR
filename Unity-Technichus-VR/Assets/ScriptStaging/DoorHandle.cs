using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  

public class DoorHandle : MonoBehaviour {  
    public string sceneBowling = "07BRockBowl/BRockBowl";
    public string sceneStaging = "Scenes/Staging";
    void OnTriggerEnter(Collider other) {
        //Checks if the bowlingball has colided with the backwall or the floor and calls respawn function
        if(other.gameObject.name == "door_handle") {
            if(SceneManager.GetActiveScene().name == "BRockBowl"){
                SceneManager.LoadScene(sceneStaging);
            }else if (SceneManager.GetActiveScene().name == "Staging")
            {
                SceneManager.LoadScene(sceneBowling);
            }
            //Debug.Log("Inne i if satsen");
            //LoadScene(sceneName);
        }
        //Debug.Log("Inne i ontrigger");
    }
    //Load an Scene
    /*public void LoadScene(string sceneName) {  
        //SceneManager.LoadScene(sceneName);  
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }*/
}  
