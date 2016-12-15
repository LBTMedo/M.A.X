using UnityEngine;
using System.Collections;

public class ThrowPleagueBall : MonoBehaviour {

    public GameObject prefab;
    float randomTimeSpawn = 0;
    bool cooldown;
    public float minTimeSpawn;
    public float maxTimeSpawn;

    public void ThrowBall()
    {
        randomTimeSpawn = Random.Range(minTimeSpawn, maxTimeSpawn);


    }
}
