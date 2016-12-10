using UnityEngine;
using System.Collections;

public class KameraEndless : MonoBehaviour {

    public Transform Igralec;

    EndlessPC igralec;
    Gorila gorila;

    Vector3 zacetnaPozicija;
    Vector3 gorilaPogled;

    public float orgSize;
    public float gorilaPogledSize;

    Camera kamera;

    bool zacetek = false;

    private void Start()
    {
        kamera = GetComponent<Camera>();

        igralec = FindObjectOfType<EndlessPC>();
        gorila = FindObjectOfType<Gorila>();

        zacetnaPozicija = Igralec.position;

        gorilaPogled = new Vector3(-26f, 1.2f);

        orgSize = kamera.orthographicSize;

        gorilaPogledSize = 3.8f;

        Invoke("PoglejGorilo", 1f);
    }

    private void FixedUpdate()
    {
        if (zacetek)
        {
            transform.position = Vector3.Lerp(transform.position, Igralec.position, 0.1f);
        }
    }

    void PoglejGorilo()
    {
        Debug.Log("Poglej Gorilo");
        transform.position = gorilaPogled;
        kamera.orthographicSize = gorilaPogledSize;

        // Animacija

        Invoke("VrniPogled", 4f);
    }

    void VrniPogled()
    {
        Debug.Log("VrniPogled");
        transform.position = Igralec.position;
        kamera.orthographicSize = orgSize;

        Invoke("Zacni", 3f);
    }

    void Zacni()
    {
        Debug.Log("Zacetek");
        igralec.zacetek = true;
        gorila.zacetek = true;
        zacetek = true;
    }
}
