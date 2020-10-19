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

    public bool resultSentToAnalytics = false;
    public TMP_Text textObject;
    
    void Start()
    {
        numFatsLeft = 4;
        this.gameObject.GetComponent<ApolloAnalytics>().setLevel(1);
    }

    void Update()
    {
        textObject.text = "to be Freed : " + numFatsLeft;
        if (numFatsLeft == 0 && TimerPanel.GetComponent<Timer>().timeRemaining > 0) {
            successObj.SetActive(true);
            TimerPanel.GetComponent<Timer>().stopTime = true;
            if(!resultSentToAnalytics) {
                Debug.Log("won!!");
                this.gameObject.GetComponent<ApolloAnalytics>().levelWin(1);

                resultSentToAnalytics = true;
            }
        }
        else if (TimerPanel.GetComponent<Timer>().timeRemaining < 0.01) {
            failObj.SetActive(true);
              if(!resultSentToAnalytics) {
                this.gameObject.GetComponent<ApolloAnalytics>().levelLose(1);
                resultSentToAnalytics = true;
            }
        }
    }

    void PauseGame() 
    {

    }

    void ResumeGame() 
    {

    }
}
