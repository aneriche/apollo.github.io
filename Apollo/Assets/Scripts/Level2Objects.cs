using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Level2Objects : MonoBehaviour
{
    public int numFatsLeft;
    [SerializeField] private GameObject TimerPanel;
    [SerializeField] private GameObject failObj;
    [SerializeField] private GameObject successObj;
    [SerializeField] private GameObject player;
    public Transform finish;
    public bool resultSentToAnalytics = false;

    public TMP_Text textObject;
    
    void Start()
    {
        this.gameObject.GetComponent<ApolloAnalytics>().setLevel(2);
        numFatsLeft = 4;
    }

    void Update()
    {
        float dist = Mathf.Abs(player.gameObject.transform.position.z - finish.position.z);
        textObject.text = dist + "m";
        if (dist < 0.5 && TimerPanel.GetComponent<Timer>().timeRemaining > 0) {
            successObj.SetActive(true);
            TimerPanel.GetComponent<Timer>().stopTime = true;
            if(!resultSentToAnalytics) {
                Debug.Log("won!!");
                this.gameObject.GetComponent<ApolloAnalytics>().levelWin(2);
                resultSentToAnalytics = true;
            }
        }
        else if (TimerPanel.GetComponent<Timer>().timeRemaining < 0.01) {
            failObj.SetActive(true);
            if(!resultSentToAnalytics) {
                this.gameObject.GetComponent<ApolloAnalytics>().levelLose(2);
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
