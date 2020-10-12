using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformExtension : MonoBehaviour
{

    void Update()
    {
        transform.position += new Vector3(0,0,Time.deltaTime*10);
    }

  
}


