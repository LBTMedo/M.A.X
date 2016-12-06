using UnityEngine;
using System.Collections;

public class Multiplier_pickup : MonoBehaviour {

    public int times = 2;

    GenerateLevel generator;

    private void Start()
    {
        generator = FindObjectOfType<GenerateLevel>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Debug pobran!");
            generator.ChangeMultiplier(times);
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
