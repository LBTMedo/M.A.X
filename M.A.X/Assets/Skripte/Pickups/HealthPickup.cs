using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

    public float dodanHealth = 50f;


    void OnTriggerEnter2D(Collider2D other)
    {
        Igralec igralec = other.gameObject.GetComponent<Igralec>();
        float dodaj;
        if(igralec.trenutnaZivljenja <= 50f)
        {
            dodaj = dodanHealth;
        }
        else
        {
            dodaj = igralec.zacetnaZivljenja - igralec.trenutnaZivljenja;
        }

        igralec.DodajZivlenja(dodaj);
        Destroy(gameObject);
    }
    
}
