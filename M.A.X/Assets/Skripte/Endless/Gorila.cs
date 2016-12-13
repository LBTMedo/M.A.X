using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gorila : MonoBehaviour {

    EndlessPC igralec;

    Queue<Vector3> pozicije;

    float timer;
    bool zagnano;

    public bool zacetek;

    private void Start()
    {
        igralec = FindObjectOfType<EndlessPC>();

        timer = 2f;
        zagnano = false;

        pozicije = new Queue<Vector3>();

        zacetek = false;
    }

    private void FixedUpdate()
    {
        if (zacetek)
        {
            DobiPozicijoIgralca();
            if (zagnano)
            {
                Sledi();
            }
        }

        if(Vector2.Distance(transform.position, igralec.transform.position) <= 2f)
        {
            // Animacija skoka na igralca
            Debug.Log("Skok na igralca!!!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            igralec.gameObject.GetComponent<Igralec>().PrejmiSkodo(1000f);
        }
    }

    private void Update()
    {
        if (!zagnano && zacetek)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                zagnano = true;
            }
        }
    }

    void DobiPozicijoIgralca()
    {
        pozicije.Enqueue(igralec.transform.position);
    }

    void Sledi()
    {
        transform.position = pozicije.Dequeue();
    }
}
