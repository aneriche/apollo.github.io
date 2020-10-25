using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCell : MonoBehaviour
{
    public Transform[] target;  
    public float speed;  
    private int current;  
    public bool dontMove = false;
    public GameObject fat;
    public ParticleSystem system;
    void Start() {
    }  
    
    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Door") {
            //Debug.Log("true");
            dontMove = true;
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
        /*if (!dontMove) {
            if (transform.position != target[current].position) 
            {  
                Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);  
                GetComponent<Rigidbody>().MovePosition(pos);  
            } 
            else current = (current + 1) % target.Length;  
        }
        else {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }*/

        if (fat == null) {
            if (transform.position != target[current].position) 
            {  
                Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);  
                GetComponent<Rigidbody>().MovePosition(pos);  
                if (system != null) {
                    system.Play(true);
                }
            } 
            else current = (current + 1) % target.Length;  
        }
        else {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (system != null) {
                system.Pause(true);
            }
        }
    }  
}
