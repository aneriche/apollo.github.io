using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCollision : MonoBehaviour
{
   [SerializeField] private Image keyImage;

    public bool obtainedKey;
	void OnCollisionEnter(Collision other) 
    {
            Debug.Log("Before");
            Debug.Log(keyImage.enabled);
            Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player" && keyImage.enabled == true)
        {
	    Debug.Log("After");
            Destroy (this.gameObject);
        }
    }
}
