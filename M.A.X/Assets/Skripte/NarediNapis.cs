using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NarediNapis : MonoBehaviour {
    public GameObject objekt;
    
    void OnTriggerEnter2D(Collider2D other)
    { 
        objekt.GetComponent<Text>().text = "Del Zgodbe";
    }
}
