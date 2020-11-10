using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugPanel : MonoBehaviour
{
    private TMP_Text textObject;
    public GameObject Player;

    void Start() {
        textObject = GetComponent<TMP_Text>();
    }
    void Update()
    {
        textObject.text = "Complete Levels : " + GameStatus.numLevelsComplete + "\n"
            + "In Menu : " + GameStatus.inMenu + "\n"
            + "Pos : " + GameStatus.playerPositionInMenuX + ", " + GameStatus.playerPositionInMenuY + ", " + GameStatus.playerPositionInMenuZ
            + "\nCurr : " + Player.transform.position.x + ", " + Player.transform.position.y + ", " + Player.transform.position.z;
    }
}
