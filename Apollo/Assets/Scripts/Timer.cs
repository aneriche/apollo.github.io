using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public TMP_Text textObject;
    public bool stopTime;

    void Start() {
        setUpTimer(90);
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
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        textObject.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Update is called once per frame
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
