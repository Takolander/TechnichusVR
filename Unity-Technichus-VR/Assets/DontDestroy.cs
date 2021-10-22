using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    Scene scene;
    SpawnPoint spawn;
    private static DontDestroy instance = null;

    public static bool created = false;
    
    void Awake(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
         if (objs.Length > 1)
        {
            DestroyImmediate(this.gameObject);
        } else {
            DontDestroyOnLoad(this.gameObject);
        }
        /*if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        } else {
            Destroy(this.gameObject);
        }*/
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
        } else if (scene.name == "Staging") {
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
