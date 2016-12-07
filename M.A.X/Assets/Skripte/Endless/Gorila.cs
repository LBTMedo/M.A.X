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
