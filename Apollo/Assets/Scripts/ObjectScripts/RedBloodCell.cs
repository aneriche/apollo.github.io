using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedBloodCell : MonoBehaviour
{
    public Transform[] target;  
    public float speed;  
    private int current;  
    public bool dontMove = false;
    public GameObject fat;
    public ParticleSystem system;
    public string level;
    public GameObject Player;
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private GameObject closePanel;

    void Start() {
    }  
    
    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Door") {
            //Debug.Log("true");
            dontMove = true;
        }
        if (col.collider.tag == "Player") {
            //Physics.IgnoreCollision(GetComponent<Collider>(), col.collider);
            GameStatus.playerPositionInMenuX = Player.transform.position.x;
            GameStatus.playerPositionInMenuY = Player.transform.position.y;
            GameStatus.playerPositionInMenuZ = Player.transform.position.z;
            GameStatus.inMenu = 0;
            GameStatus.leftGone = 1;
            levelPanel.gameObject.SetActive(true);
            closePanel.gameObject.SetActive(true);
            //SceneManager.LoadScene(level);
        }
        if (col.collider.tag == "Transparent") {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.collider.tag == "Door") {
            //Debug.Log("false");a
        }
    }

    void Update() { 
        if (fat == null && !dontMove) {
            if (transform.position != target[current].position) 
            {  
                Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);  
                GetComponent<Rigidbody>().MovePosition(pos);  
                if (system != null) {
                    system.Play(true);
                }
            } 
            else current = (current + 1) % target.Length;  
        }
        else {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (system != null) {
                system.Pause(true);
            }
        }
    }  
}
