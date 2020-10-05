using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_wall : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "wallx")
        {
            Destroy(col.collider.gameObject);
        }
    }
    //public class triggerChangeMaterial : MonoBehaviour
    //{

    //    public Material baseMaterial;
    //    public Material fadeMaterial;

    //    void OnTriggerEnter(Collider other)
    //    {
    //        Debug.Log("Player has entered the trigger");

    //        if (other.gameObject.tag == "Player")
    //        {
    //            GetComponent<Renderer>().material = fadeMaterial;
    //        }
    //    }

    //    void OnTriggerExit(Collider other)
    //    {
    //        Debug.Log("Player has exited the trigger");

    //        if (other.gameObject.tag == "Player")
    //        {
    //            GetComponent<Renderer>().material = baseMaterial;
    //        }
    //    }
    //}
}
