using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ApolloAnalytics : MonoBehaviour
{
    static Dictionary<string, object> keyCollectionTime = new Dictionary<string, object>();
    static Dictionary<string, float> keyToKeyTime = new Dictionary<string, float>();

    static int keysCollected=0;

    static Dictionary<string, float> keyToDoorTimings = new Dictionary<string, float>();
    static Dictionary<string, object> doorToDoorTimings = new Dictionary<string, object>();

    static Dictionary<string, int> powerUpCollection = new Dictionary<string, int>();

    static int totalPowerUpsSpawned = 0;
    static int doorsCrossed = 0;

    static int level = 1;
    // int level = 2;
    // int level = 3;


    //time passed since start of the level
    float time = 0;

    static int doorsCollidedWithoutKey = 0;
    static int timePowerUpsCollected = 0;
    static Dictionary<string, object> doorCollisionsWithoutKeysTime = new Dictionary<string, object>();

    void Start()
    {
        newLevel();
    }

    public void setLevel(int levelNum) {
        level = levelNum;
        // Debug.Log(level);
        newLevel();
    }
    public void initializePowerUpDictionary(){
        powerUpCollection.Add("Time",0);
    }

    public void doorCollisionsWithoutKeys(){
        doorsCollidedWithoutKey++;
        doorCollisionsWithoutKeysTime["collision" + doorsCollidedWithoutKey] = time;
       // Debug.Log(doorCollisionsWithoutKeysTime["collision" + doorsCollidedWithoutKey] + " doors collided");

    }

    public void timePowerUps(){
        timePowerUpsCollected++;
    }

    public void newLevel(){
        keyCollectionTime.Clear();
        keyToKeyTime.Clear();
        doorCollisionsWithoutKeysTime.Clear();
        keysCollected = 0;
        doorsCollidedWithoutKey = 0;

        timePowerUpsCollected = 0;
        time = 0;
    }
    public void keyCollected(){
        keysCollected = keysCollected + 1;
        keyCollectionTime["key" + keysCollected] = time;
        // Debug.Log(keyCollectionTime["key" + keysCollected]);
        // Debug.Log("keysSoFar " + keysCollected);
    }

    public void doorsPassed(){
        doorsCrossed++;
        doorToDoorTimings["door" + doorsCrossed] = time;
        //Debug.Log("doors crossexc " + doorsCrossed);
    }

    public void calculateKeyToKeyTime(){
        float lastKeyTime = 0;
        for(int i = 1; i<keysCollected; i++) {
            float timeForCurrentKey = (float)(keyCollectionTime["key" + i]);
            float timeBetweenTwoKeys = timeForCurrentKey - lastKeyTime;
            lastKeyTime = timeForCurrentKey;
            keyToKeyTime["key" + i] = timeBetweenTwoKeys;
            // Debug.Log("key" + i + " " + keyToKeyTime["key" + i]); 
        }
    }
    
    public void calculateKeyToDoorTime(){
    }

    public void powerUpsSpawned(){
        if(level == 1 || level == 2){
            totalPowerUpsSpawned = 2;
        }
    }

    // public void greenball(){

    // }

    public void levelWin(int levelNum){
        // Debug.Log("levelwin" + levelNum);
        float timeTaken = time;
        powerUpsSpawned();
        // Debug.Log("Level won");
        // Debug.Log("Level " + levelNum);
        // Debug.Log("Time taken " + timeTaken);
        // Debug.Log("TotalTimePowerUpsSpawned " + totalPowerUpsSpawned);
         Debug.Log("mTotalTimePowerUpsCollected " + timePowerUpsCollected);
        Analytics.CustomEvent("mLevelWin"+levelNum);
         Analytics.CustomEvent("mLevelWin" + levelNum, new Dictionary<string,object>{
            {"mTimeTaken", timeTaken},
            {"mTotalPowerUpsSpawned", totalPowerUpsSpawned},
            {"mTotalTimePowerUpsCollected", timePowerUpsCollected},
            {"mTotalFatBurnCollected", keysCollected},
            {"mTotalDoorsCollidedWithoutKeys", doorsCollidedWithoutKey}
        });
        // Debug.Log("key collection times");
        // foreach(KeyValuePair<string, object> entry in keyCollectionTime)
        // {
        //     Debug.Log(entry.Key + " " + entry.Value);
        // }

        // Debug.Log("door to door times");

        //   foreach(KeyValuePair<string, object> entry in doorToDoorTimings)
        // {
        //     Debug.Log(entry.Key + " " + entry.Value);
        // }
        //   foreach(KeyValuePair<string, object> entry in doorCollisionsWithoutKeysTime)
        // {
        //     Debug.Log(entry.Key + " " + entry.Value);
        // }
        AnalyticsResult analyticsResult1 =  Analytics.CustomEvent("mLevelWin" + levelNum + "keyPowerUpCollectionTime", keyCollectionTime);
        AnalyticsResult analyticsResult2 = Analytics.CustomEvent("mLevelWin" + levelNum + "FatBurningTime", doorToDoorTimings);
        AnalyticsResult analyticsResult3 = Analytics.CustomEvent("mLevelWin" + levelNum + "DoorCollisionsWithoutKeysTime", doorCollisionsWithoutKeysTime);


        // Debug.Log("analyticsResult1 " + analyticsResult1);
        // Debug.Log("analyticsResult2 " + analyticsResult2);
        // Debug.Log("analyticsResult3 " + analyticsResult3);

    }

    public void levelLose(int levelNum){
        powerUpsSpawned();
        Analytics.CustomEvent("mLevelLose" + levelNum);
         AnalyticsResult analyticsResult4 = Analytics.CustomEvent("mLevelLose" + levelNum, new Dictionary<string,object>{
            {"mTotalPowerUpsSpawned", totalPowerUpsSpawned},
            {"mTotalTimePowerUpsCollected", timePowerUpsCollected},
            {"mTotalFatBurnCollected", keysCollected},
            {"mTotalDoorsCollidedWithoutKeys", doorsCollidedWithoutKey},
            {"mTotalDoorsCrossed", doorsCrossed}
        });

        // Debug.Log("key collection times");
        // foreach(KeyValuePair<string, object> entry in keyCollectionTime)
        // {
        //     Debug.Log(entry.Key + " " + entry.Value);
        // }

        // Debug.Log("door to door times");

        //   foreach(KeyValuePair<string, object> entry in doorToDoorTimings)
        // {
        //     Debug.Log(entry.Key + " " + entry.Value);
        // }
        //   foreach(KeyValuePair<string, object> entry in doorCollisionsWithoutKeysTime)
        // {
        //     Debug.Log(entry.Key + " " + entry.Value);
        // }
        
        AnalyticsResult analyticsResult1 =  Analytics.CustomEvent("mLevelLose" + levelNum + "keyPowerUpCollectionTime", keyCollectionTime);
        AnalyticsResult analyticsResult2 = Analytics.CustomEvent("mLevelLose" + levelNum + "FatBurningTime", doorToDoorTimings);
        AnalyticsResult analyticsResult3 = Analytics.CustomEvent("mLevelLose" + levelNum + "DoorCollisionsWithoutKeysTime", doorCollisionsWithoutKeysTime);


        // Debug.Log("analyticsResult1 " + analyticsResult1);
        // Debug.Log("analyticsResult2 " + analyticsResult2);
        // Debug.Log("analyticsResult3 " + analyticsResult3);

        // Debug.Log("analyticsResult4 " + analyticsResult4);
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
   
    }
}
