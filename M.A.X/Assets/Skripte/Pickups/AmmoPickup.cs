using UnityEngine;
using System.Collections;

public class AmmoPickup : MonoBehaviour {

    public int ammoAmmount = 10;
    Ammo ammo;

    void Start()
    {
        ammo = FindObjectOfType<Ammo>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Igralec_borba igralec = other.gameObject.GetComponent<Igralec_borba>();
            ammo.PovecajSTMetkov(ammoAmmount, igralec.trenutniMetek);
            Destroy(gameObject);
        }
    }
}
