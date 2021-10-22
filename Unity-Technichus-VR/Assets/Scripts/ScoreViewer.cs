using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour
{
    public Text scoreText;

    void Awake()
    {
        scoreText = gameObject.GetComponentInChildren(typeof(Text)) as Text;
    }

    void Start()
    {
        scoreText.text = "Neon Bowling";    
    }
}
