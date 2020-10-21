using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallSpawn : MonoBehaviour
{
    public GameObject spawn;
    public GameObject spawnPoint;
    public GameObject rbc;
    public Transform[] rbcPoints;
    public GameObject[] fats;
    public Transform[] fatPoints;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay = 5.0f;
    public bool startSpawning = false;
    public int currFat = 0;

    public void spawnObj() {
        GameObject obj = Instantiate(spawn) as GameObject;
        obj.transform.position = spawnPoint.transform.position;
        if (stopSpawning) {
            CancelInvoke("spawnObj");
        }
    }

    public void spawnRBC() {
        GameObject obj = Instantiate(rbc) as GameObject;
        obj.transform.position = rbcPoints[Random.Range(0, rbcPoints.Length)].position;
        if (stopSpawning) {
            CancelInvoke("spawnRBC");
        }
    }
    public void spawnFat() {
        GameObject obj = Instantiate(fats[currFat]) as GameObject;
        obj.transform.position = fatPoints[0].position;
        if (stopSpawning) {
            CancelInvoke("spawnFat");
        }
        currFat = Random.Range(0, fats.Length);
    }

    void Start()
    {
        //InvokeRepeating("spawnObj", spawnTime, spawnDelay);
        InvokeRepeating("spawnRBC", spawnTime, spawnDelay);
        InvokeRepeating("spawnFat", spawnTime, spawnDelay);
    }
}
