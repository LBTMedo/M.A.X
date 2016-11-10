using UnityEngine;
using System.Collections;

public class Paralaxing : MonoBehaviour {

    public Transform[] Odzadja;     //array vseh odzadij da se premikajo
    private float[] paralaxUtezi;   // koliko se odzadja premikajo z kamero
    public float smoothing = 1;         // Kak gladek je paralax nad 0

    private Transform cam;
    private Vector3 prejsnaPozicijaKamere;

    void Awake()
    {
        //nastavitev reference za kamero
        cam = Camera.main.transform;

    }
	// Use this for initialization
	void Start () {
        // prejšnjo sliko bomo shranili 
        prejsnaPozicijaKamere = cam.position;

        paralaxUtezi = new float[Odzadja.Length];
        for(int i = 0; i < Odzadja.Length; i++)
        {
            paralaxUtezi[i] = Odzadja[i].position.z * -1;
        }
	
	}
	
	// Update is called once per frame
	void Update () {
        // for damo da gremo v vsako odzadje
	for(int i = 0; i < Odzadja.Length; i++)
        {
            // efekt mora bit razlika kje je bila kamera prej, kje zdaj, nato pomnožimo z utežjo
            float parallax = (prejsnaPozicijaKamere.x - cam.position.x) * paralaxUtezi[i];
            float OdzadjeTargetPosX = Odzadja[i].position.x + parallax;


            Vector3 PozicijaOdzadja = new Vector3(OdzadjeTargetPosX, Odzadja[i].position.y, Odzadja[i].position.z);
            Odzadja[i].position = Vector3.Lerp(Odzadja[i].position, PozicijaOdzadja, smoothing * Time.deltaTime);

        }
        //nastavimo 
        prejsnaPozicijaKamere = cam.position;
	}
}
