using UnityEngine;
using UnityEngine.UI;

public class KeyCollision : MonoBehaviour
{ 
    [SerializeField] private Image keyImage;

    public bool obtainedKey;

	void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {
            obtainedKey = true;
            Destroy (this.gameObject);
            keyImage.enabled = true;
        }
    }
}
