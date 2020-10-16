using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBCMove1Axis : MonoBehaviour
{ 
    public float speed;  
    private int current;  
    public bool dontMove = false;
    public GameObject fat;
    void Start() {
    }  
    
    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Door") {
            //Debug.Log("true");
            //dontMove = true;
        }
        if (col.collider.tag == "Player") {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
        }
        if (col.collider.tag == "Transparent") {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionExit(Collision col) {
        //dontMove = false;
        if (col.collider.tag == "Door") {
            //Debug.Log("false");
            //dontMove = false;
        }
    }

    void Update() { 
        transform.position += new Vector3(0,0,Time.deltaTime*-6);
    }  
}
