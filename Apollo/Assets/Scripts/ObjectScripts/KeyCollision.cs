using UnityEngine;

public class KeyCollision : MonoBehaviour
{ 
	void OnCollisionEnter(Collision other) 
    {
        if (other.collider.tag == "Player") {
            Destroy (this.gameObject);
        }
    }
}
