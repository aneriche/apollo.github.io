using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Door") {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
        }
    }
}
