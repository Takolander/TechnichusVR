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
        scoreText = gameObject.GetComponentInChildren(typeof(Text)) as Text;
    }

    void Start()
    {
        scoreText.text = "Neon Bowling";    
    }

    void displayScore()
    {
        Debug.Log("Skriver ut score");
       
        int fallenPins = pinManager.numberOfFallenPins;
        Debug.Log("Anatal nedslagna pins (ScoreViewer)" + fallenPins);
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
        pinManager.numberOfFallenPins = 0;
    }
}
