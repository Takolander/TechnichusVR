using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour
{
    private PinMangement pinManager;
    private Text scoreText;

    void Awake()
    {
        pinManager = GameObject.FindObjectOfType(typeof(PinMangement)) as PinMangement;
        scoreText = GetComponent<Text>();
    }

    void Start()
    {
        scoreText.text = "Neon Bowling";    
    }

    void displayScore()
    {
        if (pinManager.numberOfThrows == 0) return;
       
        int fallenPins = pinManager.numberOfFallenPins;
        switch (fallenPins)
        {
            case 10:
                if (pinManager.numberOfThrows == 2)
                {
                    scoreText.text = "SPARE!";
                    break;
                }
                scoreText.text = "STRIKE!";
                break;
            default:
                scoreText.text = fallenPins.ToString();
                break;
        }
    }
}
