using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour {

    public GameObject prefab;
    public float startTime;
    public float shootingCooldown;
    public bool destroyObject = true;
    public float timeToDestroy;
    

    void Start()
    {
        InvokeRepeating("SpawnArrow", startTime, shootingCooldown);
    }

    void SpawnArrow()
    {
        GameObject nov = (GameObject)Instantiate(prefab, transform.position, prefab.transform.rotation);
        if(destroyObject)
        DestroyObject(nov);
    }

    void DestroyObject(GameObject toDestroy)
    {
        Destroy(toDestroy,timeToDestroy);
    }
}
