using UnityEngine;

public class Level3Objects: MonoBehaviour{
    [SerializeField] private GameObject TimerPanel;
    [SerializeField] private GameObject failObj;
    [SerializeField] private GameObject successObj;

    public int numberOfObjectsCollected;
    public bool resultSentToAnalytics = false;

    void Start(){
        numberOfObjectsCollected = 0;
        this.gameObject.GetComponent<ApolloAnalytics>().setLevel(3);
    }

    void Update(){
        if(numberOfObjectsCollected == 5 && TimerPanel.GetComponent<Timer>().timeRemaining > 0) {
            successObj.SetActive(true);
            TimerPanel.GetComponent<Timer>().stopTime = true;
              if(!resultSentToAnalytics) {
                Debug.Log("won!!");
                this.gameObject.GetComponent<ApolloAnalytics>().levelWin(3);
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

}