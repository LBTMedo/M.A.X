using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZagePadajo : MonoBehaviour
{

    [SerializeField]
    GameObject parent;
    Transform[] children;

    public GameObject[] prefab;


    GumbZaZage gumb1;

    void Start()
    {
        children = parent.GetComponentsInChildren<Transform>();
        gumb1 = FindObjectOfType<GumbZaZage>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
            GenerateAndDropObjects();

    }

    public void GenerateAndDropObjects()
    {
       
        
            Instantiate(prefab[0], children[1].position, children[1].rotation);
        

    }


}
