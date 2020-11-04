using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPanel : MonoBehaviour
{
    public TMP_Text textObject;
    public GameObject Player;

    private int keyCount;
    private int pillCount;

    void Start() {
        keyCount = 0;
        pillCount = 0;
    }

    void Update() {
        keyCount = Player.gameObject.GetComponent<PlayerInfo>().keyCount;
        pillCount = Player.gameObject.GetComponent<PlayerInfo>().pillCount;
        if (keyCount > 0) 
        {
            textObject.text = "x" + keyCount;
        }
        if (textObject.name == "Pill Count")
        {
            textObject.text = "x" + pillCount;
        }
        
    }
}
