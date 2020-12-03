using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPill : MonoBehaviour
{
    [SerializeField] private GameObject menuPillPanel;
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private GameObject closePanel;
    public ParticleSystem system;
    public GameObject Player;

    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Player") {
            GameStatus.playerPositionInMenuX = Player.transform.position.x;
            GameStatus.playerPositionInMenuY = Player.transform.position.y;
            GameStatus.playerPositionInMenuZ = Player.transform.position.z;
            GameStatus.inMenu = 0;
            menuPillPanel.gameObject.SetActive(true);
            levelPanel.gameObject.SetActive(true);
            closePanel.gameObject.SetActive(true);
            system.Play(true);
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.collider.tag == "Player") {
            system.Stop(true);
            menuPillPanel.gameObject.SetActive(false);
        }
    }
    
    void Start()
    {
        if (system != null) {
            system.Pause(true);
        }
    }
    
    void Update()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
