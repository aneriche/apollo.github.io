using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldCollision : MonoBehaviour
{
    void OnCollisionEnter (Collision col) {
        if (col.collider.tag == "Door") {
            Destroy(col.collider.gameObject);
        }
        else if (col.collider.tag == "Key") {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
        }
        else if (col.collider.tag == "Player") {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
        }
        else {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
        }
    }
}
