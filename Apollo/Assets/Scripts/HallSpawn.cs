using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallSpawn : MonoBehaviour
{
    public GameObject spawn;
    public GameObject spawnPoint;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay = 5.0f;
    public bool startSpawning = false;
    // Start is called before the first frame update

    public void spawnObj() {
        GameObject obj = Instantiate(spawn) as GameObject;
        obj.transform.position = spawnPoint.transform.position;
        if (stopSpawning) {
            CancelInvoke("spawnObj");
        }
    }

    IEnumerator spawnCR() {
        while (startSpawning) {
            yield return new WaitForSeconds(spawnDelay);
            if (stopSpawning) break;
            //spawnEnemy();
        }
    }

    void Start()
    {
        InvokeRepeating("spawnObj", spawnTime, spawnDelay);
        //StartCoroutine(spawnCR());
    }
}
