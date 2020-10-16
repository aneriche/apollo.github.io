using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Level1Objects : MonoBehaviour
{
    public int numFatsLeft;
    [SerializeField] private GameObject TimerPanel;
    [SerializeField] private GameObject failObj;
    [SerializeField] private GameObject successObj;

    public TMP_Text textObject;
    
    void Start()
    {
        numFatsLeft = 4;
    }

    void Update()
    {
        textObject.text = "to be Freed : " + numFatsLeft;
        if (numFatsLeft == 0 && TimerPanel.GetComponent<Timer>().timeRemaining > 0) {
            successObj.SetActive(true);
            TimerPanel.GetComponent<Timer>().stopTime = true;
        }
        else if (TimerPanel.GetComponent<Timer>().timeRemaining < 0.01) {
            failObj.SetActive(true);
        }
    }

    void PauseGame() 
    {

    }

    void ResumeGame() 
    {

    }
}
