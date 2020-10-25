using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerAnalog : MonoBehaviour
{
    public float timer_duration; //time duration in seconds
    public float timerLimit;
    public Image fillImage;
    public GameObject TimerPanel;
    private IEnumerator co;
    private float fillValue;

    // Start is called before the first frame update
    void Start()
    {
        fillImage.fillAmount = 1f;
        timerLimit = TimerPanel.GetComponent<Timer>().timeRemaining;
        fillValue = 0;
    }

    void Update() {
        bool stop = TimerPanel.GetComponent<Timer>().stopTime;
        timer_duration = TimerPanel.GetComponent<Timer>().timeRemaining;
        if (!stop){
            if (timer_duration > 0) {
                fillValue = timer_duration / timerLimit;
                fillImage.fillAmount = fillValue;
            }
        }
    }

    // Update is called once per frame
    public IEnumerator Timer()
    {
        float startTime = Time.time;
        float time = timer_duration;
        float value = 0;

        while (Time.time - startTime < timer_duration)
        {
            time -= Time.deltaTime;
            value = time / timer_duration;
            fillImage.fillAmount = value;
            yield return null;
        }
    }
}
