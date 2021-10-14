using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{ 
    public float timer = 10f;
    public GameObject Epilepsy;
    public GameObject Equipment;
    public GameObject Gameplay;
    // Start is called before the first frame update
    void Start()
    {
        Epilepsy.SetActive(true);
        Equipment.SetActive(false);
        Gameplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0){
            if(Epilepsy.activeSelf == true && Equipment.activeSelf == false && Gameplay.activeSelf == false){
                Epilepsy.SetActive(false);
                Equipment.SetActive(true);
                timer = 10f;
            } else if (Epilepsy.activeSelf == false && Equipment.activeSelf == true && Gameplay.activeSelf == false)
            {
                Gameplay.SetActive(true);
                Equipment.SetActive(false);
                timer = 10f;
            } else if (Epilepsy.activeSelf == false && Equipment.activeSelf == false && Gameplay.activeSelf == true)
            {
                Gameplay.SetActive(false);
                Epilepsy.SetActive(true);
                timer = 10f;
            }
        }
    }
}
