using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPanel : MonoBehaviour
{
    public TMP_Text textObject;
    public GameObject Player;

    private int keyCount;

    void Start() {
        keyCount = 0;
    }

    void Update() {
        keyCount = Player.gameObject.GetComponent<PlayerInfo>().keyCount;
        if (keyCount > 0) 
        {
            textObject.text = "x" + keyCount;
        }
    }
}
