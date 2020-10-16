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

    public TMP_Text textObject;
    
    void Start()
    {
        numFatsLeft = 4;
    }

    void Update()
    {
        float dist = Vector3.Distance(player.gameObject.transform.position, finish.position);
        textObject.text = dist + "m";
        if (dist < 0.5 && TimerPanel.GetComponent<Timer>().timeRemaining > 0) {
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
