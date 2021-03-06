using UnityEngine;

public class Level3Objects: MonoBehaviour{
    [SerializeField] private GameObject TimerPanel;
    [SerializeField] private GameObject failObj;
    [SerializeField] private GameObject successObj;
    [SerializeField] private GameObject player;

    public int numberOfObjectsLeft;
    public bool resultSentToAnalytics = false;

    public bool doOnce = true;

    void Start(){
        numberOfObjectsLeft = -1;
        this.gameObject.GetComponent<ApolloAnalytics>().setLevel(3);
    }

    void Update(){
        numberOfObjectsLeft = player.gameObject.GetComponent<PlayerInfo>().pillCount;
        if(numberOfObjectsLeft == 0 && TimerPanel.GetComponent<Timer>().timeRemaining > 0) {
            successObj.SetActive(true);
            TimerPanel.GetComponent<Timer>().stopTime = true;
            if (doOnce) {
                GameStatus.numLevelsComplete += 1;
                GameStatus.inMenu = 1;
                doOnce = false;
            }
              if(!resultSentToAnalytics) {
                Debug.Log("won!!");
                this.gameObject.GetComponent<ApolloAnalytics>().levelWin(3);
                resultSentToAnalytics = true;
            }
        }
        else if (TimerPanel.GetComponent<Timer>().timeRemaining < 0.01) {
            failObj.SetActive(true);
            if (doOnce) {
                GameStatus.inMenu = 1;
            }
            if(!resultSentToAnalytics) {
                this.gameObject.GetComponent<ApolloAnalytics>().levelLose(1);
                resultSentToAnalytics = true;
            }
        }
    }

}