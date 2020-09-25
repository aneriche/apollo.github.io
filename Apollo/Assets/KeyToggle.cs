using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class KeyToggle : MonoBehaviour
{
 
    public Renderer key;
 
    
    void Start() {
        key = gameObject.GetComponentInChildren<Renderer>();  
    }
 
    public void displayKey() {
        key.enabled = true;
    }   
 
    public void hideKey() {
        key.enabled = false;
    }
 
    public void moveToLocation(float x,float y, float z){
        key.transform.position = new Vector3(x,y,z);
    }
 
 
}
 
 

