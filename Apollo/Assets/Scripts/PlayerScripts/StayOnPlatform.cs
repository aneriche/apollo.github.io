using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnPlatform : MonoBehaviour
{
    private CharacterController controller;
    public Transform CenterPoint;
    public float OrbitSpeed;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
            other.transform.parent = transform;
            Debug.Log(transform.position);
            //gameObject.AddComponent<FixedJoint>();
            //gameObject.GetComponent<FixedJoint>().connectedBody = other.gameObject.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        other.transform.position = RotatePointAroundPivot(other.transform.position, CenterPoint.transform.position, Quaternion.Euler(0, OrbitSpeed, 0));
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
            Debug.Log(transform.position);
            //Destroy(gameObject.GetComponent<FixedJoint>());
        }
    }
    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle)
    {
        return angle * (point - pivot) + pivot;
    }
}
