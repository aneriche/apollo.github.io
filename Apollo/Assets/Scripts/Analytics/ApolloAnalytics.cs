using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApolloAnalytics : MonoBehaviour
{
    Dictionary<string, float> keyCollectionTime = new Dictionary<string, float>();
     Dictionary<string, float> keyToKeyTime = new Dictionary<string, float>();

    int keysCollected = 0;

    Dictionary<string, float> keyToDoorTimings = new Dictionary<string, float>();
    Dictionary<string, float> doorToDoorTimings = new Dictionary<string, float>();

    int doorsCrossed = 0;

    int level = 1;

    //time passed since start of the level
    float time = 0;
    void Start()
    {
        
    }

    public void newLevel(){
        keyCollectionTime = new Dictionary<string, float>();
        keyToKeyTime = new Dictionary<string, float>();
        keysCollected = 0;

        level++;

        time = 0;
    }
    public void keyCollected(){
        // string lastKeyCollected = "key" + keysCollected;
        // float timeForLastKey = keyCollectionTime.ContainsKey(lastKeyCollected) ? keyCollectionTime[lastKeyCollected]: 0;
        // float timeBetweenTwoKeyCollection = time - timeForLastKey;
        // Debug.Log("last key collected " + lastKeyCollected);
        // Debug.Log("current time"+ time);
        // Debug.Log("timeBetweenTwoKeyCollection " + timeBetweenTwoKeyCollection);
        keysCollected++;
        keyCollectionTime["key" + keysCollected] = time;
        Debug.Log(keyCollectionTime["key" + keysCollected]);
    }

    public void doorsPassed(){
        doorsCrossed++;
        doorToDoorTimings["door" + doorsCrossed] = time;
    }

    public void calculateKeyToKeyTime(){
        float lastKeyTime = 0;
        for(int i = 1; i<keysCollected; i++) {
            float timeForCurrentKey = keyCollectionTime["key" + i];
            float timeBetweenTwoKeys = timeForCurrentKey - lastKeyTime;
            lastKeyTime = timeForCurrentKey;
            keyToKeyTime["key" + i] = timeBetweenTwoKeys;
            Debug.Log("key" + i + " " + keyToKeyTime["key" + i]); 
        }
    }
    
    public void calculateKeyToDoorTime(){
    }

    public void levelWin(){
        calculateKeyToKeyTime();
        /***TODO: @Mansi
        Send keyCollectionTime dictionary to analytics
        Send keyToDoor timings dictionary to analytics
        Send ("levelWin", level) as a key-value pair to find the level cleared
        Send ("level + levelnumber + win", numberOfCollisions) eg, (level1Win, 12)
        ***/

    }

    public void levelLose(){
        /***TODO: @Mansi
        Send ("levelLost", level)
        Send ("level + levelnumber + lost", numberOfCollisions) eg, (level1Lost, 12)
        Send ("level + levelnumber + lost", doorsCrossed);
        Send ("level + levelnumber + lost", keysCollected);
        Send keyCollectionTime dictionary to analytics
        Send keyToDoor timings dictionary to analytics
        **/
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
   
    }
}
