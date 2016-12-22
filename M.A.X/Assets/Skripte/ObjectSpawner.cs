using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour {

    public GameObject prefab;
    public float startTime;
    public float shootingCooldown;

    void Start()
    {
        InvokeRepeating("SpawnObject", startTime, shootingCooldown);
    }

    void SpawnObject()
    {
        GameObject nov = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
    }
}
