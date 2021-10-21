using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    Scene scene;
    SpawnPoint spawn;
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        spawn = GameObject.FindObjectOfType(typeof(SpawnPoint)) as SpawnPoint;
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        if(scene.name == "BRockBowl") {
            Debug.Log("Gick in i if satsen");
            Debug.Log(spawn.transform.position);
            this.transform.position = spawn.transform.position;
        }
    }

    // called third
    void Start()
    {
        Debug.Log("Start");
    }

    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
