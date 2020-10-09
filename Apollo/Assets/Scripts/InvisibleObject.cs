using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleObject : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }
}
