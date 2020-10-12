using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyBlobbing : MonoBehaviour
{
public Vector3 from = new Vector3(0f, 0f, 0f);
public Vector3 to   = new Vector3(0f, 0f, 275f);
public float speed = 0.01f; 
 
 void Update() {
     float t = Mathf.PingPong(Time.time * speed, 1.0f);
     transform.eulerAngles = Vector3.Lerp (from, to, t);
 }
}
