using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnManager : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject spawnEnemy;
    
    public float delayRemaining;
    private int locationIndex;
    void Start()
    {
        delayRemaining = Random.Range(2.0f, 5.0f);
    }

    
    void Update()
    {
        if (delayRemaining <= 0.0f)
        {
            delayRemaining = Random.Range(2.0f, 5.0f);
            locationIndex = Random.Range(0, spawnLocations.Length);
            Instantiate(spawnEnemy, spawnLocations[locationIndex].transform.position, Quaternion.identity);
        }
        delayRemaining -= Time.deltaTime;
    }
}
