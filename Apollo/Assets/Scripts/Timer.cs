using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = -100f;
    public TMP_Text textObject;
    public bool stopTime;

    void Start() {
        if (timeRemaining == -100f) {
            setUpTimer(90);
        }
        else {
            setUpTimer(timeRemaining);
        }
        stopTime = false;
    }

    public void setUpTimer(float totalTime) {
        timeRemaining = totalTime;
        textObject = gameObject.GetComponent<TMP_Text>();
        timeRemaining = timeRemaining - Time.deltaTime;
        DisplayTime(timeRemaining);
    }

   void DisplayTime(float timeToDisplay)
    {
        int timeInt = (int) timeRemaining;
        textObject.text = "" + timeInt;
    }

    void Update()
    {
        if (!stopTime) {
            if(timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            } 
        }
    }
}
