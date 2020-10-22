using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerAnalog : MonoBehaviour
{
    public float timer_duration; //time duration in seconds
    public Image fillImage;

    // Start is called before the first frame update
    void Start()
    {
        fillImage.fillAmount = 1f;
        StartCoroutine(Timer(timer_duration));

    }

    // Update is called once per frame
    public IEnumerator Timer(float duration)
    {
        float startTime = Time.time;
        float time = duration;
        float value = 0;

        while (Time.time - startTime < duration)
        {
            time -= Time.deltaTime;
            value = time / duration;
            fillImage.fillAmount = value;
            yield return null;
        }

    }
}
