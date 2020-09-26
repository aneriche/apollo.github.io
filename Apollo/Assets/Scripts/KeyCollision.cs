using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollision : MonoBehaviour
{ 
	void OnCollisionEnter(Collision other)
 {
            if (other.gameObject.name == "Player")
           {
           Debug.Log("Inside");
                    Destroy (this.gameObject);
           }
 }
}
