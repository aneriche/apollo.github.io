using UnityEngine;

public class KeyCollision : MonoBehaviour
{ 

    public bool obtainedKey;

	void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {
            obtainedKey = true;
            Destroy (this.gameObject);
        }
    }
}
