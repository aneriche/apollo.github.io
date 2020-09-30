using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorFunctionality : MonoBehaviour
{
    public GameObject endDialogue;
    void OnDestroy() {
        Debug.Log("OnDestroy");
        endDialogue.SetActive(true);
    }
}
