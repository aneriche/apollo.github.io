using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatCollision : MonoBehaviour
{
    void OnCollisionEnter (Collision col) {
        if (col.collider.tag == "Key") {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
        }
        else if (col.collider.tag == "Door") {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
        }
        else if (col.collider.tag == "Transparent") {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
            //Debug.Log("transparent");
        }
        else if (col.collider.tag == "RBC") {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
        }
    }
}
