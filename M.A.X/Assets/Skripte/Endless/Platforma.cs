using UnityEngine;
using System.Collections;

public class Platforma : MonoBehaviour {

    GenerateLevel generiraj;
    bool zeZaznano = false;

    void Start()
    {
        generiraj = FindObjectOfType<GenerateLevel>();
    }

	void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player" && !zeZaznano)
        {
            zeZaznano = true;
            generiraj.SpawnNext(transform.position);
        }
    }
}
