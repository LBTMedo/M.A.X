using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour {

    public GameObject prefab;
    public float startTime;
    public float shootingCooldown;
    public bool destroyObject = true;
    public float timeToDestroy;
    public bool rotateSpawnedObject;

    void Start()
    {
        InvokeRepeating("SpawnObject", startTime, shootingCooldown);
    }

    void SpawnObject()
    {
        GameObject nov = (GameObject)Instantiate(prefab, transform.position, prefab.transform.rotation);
        if (rotateSpawnedObject)
        {
            nov.transform.Rotate(0, 180, 0);
        }
        if(destroyObject)
        DestroyObject(nov);
    }

    void DestroyObject(GameObject toDestroy)
    {
        Destroy(toDestroy,timeToDestroy);
    }
}
