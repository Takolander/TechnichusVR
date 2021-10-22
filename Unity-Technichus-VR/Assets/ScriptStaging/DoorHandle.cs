using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  

public class DoorHandle : MonoBehaviour {  
    public string sceneBowling = "07BRockBowl/BRockBowl";
    public string sceneStaging = "Scenes/Staging";

    //Triggers when entered to send player to the new scene
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "door_handle") {
            if(SceneManager.GetActiveScene().name == "BRockBowl"){
                SceneManager.LoadScene(sceneStaging);
            }else if (SceneManager.GetActiveScene().name == "Staging")
            {
                SceneManager.LoadScene(sceneBowling);
            }
        }
    }
}  
