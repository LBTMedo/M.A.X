using UnityEngine;
using System.Collections;

public class ArrowSpawner : MonoBehaviour {

    public GameObject prefab;
    Transform pozicija;

    void Start()
    {
        pozicija = GetComponent<Transform>();
        //InvokeRepeating("", 0.01f, 5.0f);
    }



    void SpawnArrow()
    {
        
    }
}
