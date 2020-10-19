using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Image keyImage;
    [SerializeField] private GameObject keyPanel;
    [SerializeField] private GameObject timerPanel;
    [SerializeField] private GameObject Manager;
    [SerializeField] private GameObject pillPanel;

    void OnCollisionEnter (Collision col) {
        if (col.collider.tag == "Key") {
            Destroy(col.collider.gameObject);
            this.gameObject.GetComponent<PlayerInfo>().keyCount++;
            this.gameObject.GetComponent<ApolloAnalytics>().keyCollected();
            keyPanel.gameObject.SetActive(true);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (col.collider.tag == "Door" && gameObject.GetComponent<PlayerInfo>().keyCount > 0) {
            this.gameObject.GetComponent<ApolloAnalytics>().doorsPassed();
            this.gameObject.GetComponent<PlayerInfo>().keyCount--;
            if (this.gameObject.GetComponent<PlayerInfo>().keyCount == 0) {
                keyPanel.gameObject.SetActive(false);
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            if (Manager.GetComponent<Level1Objects>() != null) {
                Manager.GetComponent<Level1Objects>().numFatsLeft--;
            }
            Destroy(col.collider.gameObject);
        }
        else if(col.collider.tag == "Door" && gameObject.GetComponent<PlayerInfo>().keyCount == 0) {
            this.gameObject.GetComponent<ApolloAnalytics>().doorCollisionsWithoutKeys();
        }
        else if (col.collider.tag == "Transparent") {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
            //Debug.Log("transparent");
        }
        else if (col.collider.tag == "RBC") {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
        }
        else if (col.collider.tag == "Time") {
            gameObject.GetComponent<ApolloAnalytics>().timePowerUps();
            timerPanel.GetComponent<Timer>().timeRemaining += 15;
            Destroy(col.collider.gameObject);
        }
        else if (col.collider.tag == "pill") {
            Destroy(col.collider.gameObject);
            this.gameObject.GetComponent<PlayerInfo>().pillCount++;
            pillPanel.gameObject.SetActive(true);
        }
        else if (col.collider.tag == "piece") {
	          this.gameObject.GetComponent<PlayerInfo>().pieceCount++;
            Destroy(col.collider.gameObject);
            if (this.gameObject.GetComponent<PlayerInfo>().pieceCount == 4){
	            Debug.Log("End level");
            }
        }
    }
}
