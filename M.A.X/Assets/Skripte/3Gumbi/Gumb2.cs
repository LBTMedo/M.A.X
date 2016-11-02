using UnityEngine;
using System.Collections;

public class Gumb2 : MonoBehaviour {

    public GameObject luc2;
    public static bool gumb2 = true;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (gumb2 == false)
        {
            gumb2 = true;
            luc2.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            gumb2 = false;
            luc2.GetComponent<Renderer>().material.color = Color.red;
        }

    }
    void Update()
    {
        if (gumb2 == true)
        {
            luc2.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            luc2.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
