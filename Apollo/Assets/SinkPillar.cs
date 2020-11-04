using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkPillar : MonoBehaviour
{
    [SerializeField] private GameObject TimerPanel;
    public float sinkSpeed;
    
    private Vector3 startPosition;
    public float sinkStartTime;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(TimerPanel.GetComponent<Timer>().timeRemaining < sinkStartTime)
        {
            this.gameObject.transform.position += (Vector3.down * sinkSpeed);
        }
        if(this.gameObject.transform.position.y < (startPosition + (15 * Vector3.down)).y)
        {
            Destroy(this.gameObject);
        }
    }
}
