﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Image keyImage;
    [SerializeField] private GameObject keyPanel;
    [SerializeField] private GameObject timerPanel;
    [SerializeField] private GameObject Manager;
    [SerializeField] private GameObject pillPanel;

    // onTrigger used in level2 along with collision
    void OnTriggerEnter(Collider col) {
        if (this.gameObject.GetComponent<PlayerInfo>().keyCount > 0) {
            this.gameObject.GetComponent<ApolloAnalytics>().doorsPassed();
            this.gameObject.GetComponent<PlayerInfo>().keyCount--;
            this.gameObject.GetComponent<PlayerAbility>().fillPanel(this.gameObject.GetComponent<PlayerInfo>().keyCount);
            if (this.gameObject.GetComponent<PlayerInfo>().keyCount == 0) {
                keyPanel.gameObject.SetActive(false);
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                this.gameObject.GetComponent<PlayerAbility>().clearPanel();
            }
            Destroy(col.GetComponent<Collider>().gameObject);
        }
        else if (this.gameObject.GetComponent<PlayerInfo>().keyCount == 0) {
            this.gameObject.GetComponent<ApolloAnalytics>().doorCollisionsWithoutKeys();
        }
    }

    void OnCollisionEnter (Collision col) {
        if (col.collider.tag == "Key") {
            Destroy(col.collider.gameObject);
            this.gameObject.GetComponent<PlayerInfo>().keyCount++;
            this.gameObject.GetComponent<ApolloAnalytics>().keyCollected();
            keyPanel.gameObject.SetActive(true);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.GetComponent<PlayerAbility>().fillPanel(this.gameObject.GetComponent<PlayerInfo>().keyCount);
            if (this.gameObject.GetComponent<PlayerInfo>().keyCount % 2 == 0 && this.gameObject.GetComponent<PlayerInfo>().keyCount > 0) {
                this.gameObject.GetComponent<PlayerAbility>().activateAbility();
                this.gameObject.GetComponent<PlayerAbility>().clearPanel();
            }
        }
        else if (col.collider.tag == "Door") {
            if (this.gameObject.GetComponent<PlayerInfo>().keyCount > 0) {
                this.gameObject.GetComponent<ApolloAnalytics>().doorsPassed();
                this.gameObject.GetComponent<PlayerInfo>().keyCount--;
                this.gameObject.GetComponent<PlayerAbility>().fillPanel(this.gameObject.GetComponent<PlayerInfo>().keyCount);
                Debug.Log("key down");
                if (this.gameObject.GetComponent<PlayerInfo>().keyCount == 0) {
                    keyPanel.gameObject.SetActive(false);
                    this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    this.gameObject.GetComponent<PlayerAbility>().clearPanel();
                }
                if (Manager.GetComponent<Level1Objects>() != null) {
                    Manager.GetComponent<Level1Objects>().numFatsLeft--;
                }
                Destroy(col.collider.gameObject);
            }
            else if (this.gameObject.GetComponent<PlayerInfo>().keyCount == 0) {
                this.gameObject.GetComponent<ApolloAnalytics>().doorCollisionsWithoutKeys();
            }
        }
        else if (col.collider.tag == "Transparent") {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
            //Debug.Log("transparent");
        }
        else if (col.collider.tag == "RBC") {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
        }
        else if (col.collider.tag == "Time") {
            gameObject.GetComponent<ApolloAnalytics>().timePowerUps();
            timerPanel.GetComponent<Timer>().timeRemaining += 15;
            Destroy(col.collider.gameObject);
        }
        else if (col.collider.tag == "pill") {
            Destroy(col.collider.gameObject);
            this.gameObject.GetComponent<PlayerInfo>().pillCount--;
            //pillPanel.gameObject.SetActive(true);
        }
        else if (col.collider.tag == "piece") {
	        this.gameObject.GetComponent<PlayerInfo>().pieceCount++;
            Destroy(col.collider.gameObject);
            if (this.gameObject.GetComponent<PlayerInfo>().pieceCount == 4){
	            Debug.Log("End level");
            }
        }
        else if (col.collider.tag == "forceField") {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
        }
        else if (col.collider.tag == "MenuPill") {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
        }
    }
}
