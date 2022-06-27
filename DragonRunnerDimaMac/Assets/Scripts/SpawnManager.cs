using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectToSpawn
{   
    [Range(0, 10)] public float minRate;
    [Range(0, 10)] public float maxRate;
    public GameObject spawnObject;
    [System.NonSerialized] public float nextSpawn;
}

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<ObjectToSpawn> objectsToSpawn;
    
    [SerializeField] private Vector3[] spawnPosLimits = new Vector3[2];

    void Update()
    {
        foreach (ObjectToSpawn go in objectsToSpawn)
        {
            if (Time.time > go.nextSpawn)
            {
                float randomRate = Random.Range(go.minRate, go.maxRate);
                go.nextSpawn = Time.time + randomRate;
                float randomX = Random.Range(spawnPosLimits[0].x, spawnPosLimits[1].x);
                Vector3 spawnpos = new Vector3(randomX, spawnPosLimits[0].y, spawnPosLimits[0].z);

                Instantiate(go.spawnObject, spawnpos, Quaternion.identity);
            }
        }
    }
}
