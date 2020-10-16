using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "RBC") {
            Destroy(col.collider.gameObject);
        }
        else if (col.collider.tag == "Door") {
            Destroy(col.collider.gameObject);
        }
        else if (col.collider.tag == "Despawn")
        {
            Destroy(col.collider.gameObject);
        }
        if (col.gameObject.GetComponent<ObjectInfo>() != null) {
            if (col.gameObject.GetComponent<ObjectInfo>().tags[0].Equals("Despawn")) {
                Destroy(col.collider.gameObject);
                Destroy(col.collider.gameObject.transform.parent.gameObject);
                Debug.Log("destroy");
            }
        }
    }
}
