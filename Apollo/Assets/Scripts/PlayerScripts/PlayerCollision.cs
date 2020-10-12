using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Image keyImage;
    [SerializeField] private GameObject keyPanel;
    [SerializeField] private GameObject timerPanel;

    void OnCollisionEnter (Collision col) {
        if (col.collider.tag == "Key") {
            Destroy(col.collider.gameObject);
            this.gameObject.GetComponent<PlayerInfo>().keyCount++;
            this.gameObject.GetComponent<ApolloAnalytics>().keyCollected();
            keyPanel.gameObject.SetActive(true);
        }
        else if (col.collider.tag == "Door" && gameObject.GetComponent<PlayerInfo>().keyCount > 0) {
            this.gameObject.GetComponent<ApolloAnalytics>().doorsPassed();
            this.gameObject.GetComponent<PlayerInfo>().keyCount--;
            if (this.gameObject.GetComponent<PlayerInfo>().keyCount == 0) {
                keyPanel.gameObject.SetActive(false);
            }
            Destroy(col.collider.gameObject);
        }
        else if (col.collider.tag == "Door") {
            //Debug.Log("colliding with no key");
        }
        else if (col.collider.tag == "Transparent") {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
            //Debug.Log("transparent");
        }
        else if (col.collider.tag == "RBC") {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
        }
        else if (col.collider.tag == "Time") {
            timerPanel.GetComponent<Timer>().timeRemaining += 15;
            Destroy(col.collider.gameObject);
        }
    }
}
