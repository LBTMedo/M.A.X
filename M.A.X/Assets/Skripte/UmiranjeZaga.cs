using UnityEngine;
using System.Collections;

public class UmiranjeZaga : MonoBehaviour
{

    private Igralec player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Igralec>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("collider");
        if (coll.gameObject.tag == "Player" && coll.gameObject.name == "Max")
        {
            coll.gameObject.SendMessage("PrejmiSkodo", 1000);
        }
        else
        {
            Debug.Log("collide1r");
        }

    }
}
