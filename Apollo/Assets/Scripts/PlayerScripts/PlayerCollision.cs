using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Image keyImage;

    void OnCollisionEnter (Collision col) {
        if (col.collider.tag == "Key") {
            Destroy(col.collider.gameObject);
            //Debug.Log(this.gameObject.GetComponent<PlayerInfo>().hasKey);
            this.gameObject.GetComponent<PlayerInfo>().hasKey = true;
            keyImage.enabled = true;
        }
        else if (col.collider.tag == "Door" && gameObject.GetComponent<PlayerInfo>().hasKey == true) {
            Destroy(col.collider.gameObject);
            keyImage.enabled = false;
            this.gameObject.GetComponent<PlayerInfo>().hasKey = false;
        }
        else if (col.collider.tag == "Door") {
            Debug.Log("colliding with no key");
        }
    }
}
