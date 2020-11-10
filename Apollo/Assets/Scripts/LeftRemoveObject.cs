using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRemoveObject : MonoBehaviour
{
    void Start()
    {
        if (GameStatus.leftGone == 1) {
            Destroy(this.gameObject);
        }
    }
}
