using UnityEngine;
using System.Collections;

public class Gumb3 : MonoBehaviour {

  //  public GameObject luc3;
    public static bool gumb3 = false;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (gumb3 == false)
        {
            gumb3 = true;
         //   luc3.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            gumb3 = false;
           // luc3.GetComponent<Renderer>().material.color = Color.red;
        }

    }
    void Update () {
        if (gumb3 == true)
        {
         //   luc3.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
//luc3.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
