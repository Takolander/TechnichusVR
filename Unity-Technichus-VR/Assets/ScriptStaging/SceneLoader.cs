using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  

public class SceneLoader : MonoBehaviour {  

    //Load an Scene
    public void LoadScene(string sceneName) {  
        //SceneManager.LoadScene(sceneName);  
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }  
}   