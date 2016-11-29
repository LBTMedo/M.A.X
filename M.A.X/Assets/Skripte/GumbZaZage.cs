using UnityEngine;
using System.Collections;

public class GumbZaZage : MonoBehaviour
{

    ZagePadajo objekti;

  
    void Start()
    {
        objekti = FindObjectOfType<ZagePadajo>();
        Debug.Log("Trk");

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        objekti.GenerateAndDropObjects();
        Debug.Log("Trk1");
    }

}
