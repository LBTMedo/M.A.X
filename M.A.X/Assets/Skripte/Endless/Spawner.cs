using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    private List<Transform> pickupSpots;
    public GameObject[] pickups;

    private void Start()
    {
        pickupSpots = new List<Transform>();

        foreach(Transform child in transform)
        {
            pickupSpots.Add(child);
        }

        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < pickupSpots.Count; i++)
        {
            Instantiate(pickups[Random.Range(0, pickups.Length)], pickupSpots[i].position, pickupSpots[i].rotation);
        }
    }
}
