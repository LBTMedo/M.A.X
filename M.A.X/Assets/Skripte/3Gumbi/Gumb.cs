using UnityEngine;
using System.Collections;

public class Gumb : MonoBehaviour {
    public GameObject luc1;
    public static bool gumb1 = false;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (gumb1 == false)
        {
            gumb1 = true;
            luc1.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            gumb1 = false;
            luc1.GetComponent<Renderer>().material.color = Color.red;
        }

    }
    void Update()
    {
        if (gumb1 == true)
        {
            luc1.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            luc1.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
