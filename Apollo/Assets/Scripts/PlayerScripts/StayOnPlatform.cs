using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnPlatform : MonoBehaviour
{
    private CharacterController controller;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "platform")
        {
            transform.parent = other.transform;
            Debug.Log(transform.position);
            //gameObject.AddComponent<FixedJoint>();
            //gameObject.GetComponent<FixedJoint>().connectedBody = other.gameObject.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "platform")
        {
            transform.parent = null;
            Debug.Log(transform.position);
            //Destroy(gameObject.GetComponent<FixedJoint>());
        }
    }
}
