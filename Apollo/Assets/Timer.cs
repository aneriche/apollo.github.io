using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public TextMesh textObject;

    void Start() {
        setUpTimer(30);
    }

    public void setUpTimer(float totalTime) {
        timeRemaining = totalTime;
        textObject = gameObject.GetComponent<TextMesh>();
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
        if(timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        } 
        else {
            //whatever action on end of timer
        }
    }
}
