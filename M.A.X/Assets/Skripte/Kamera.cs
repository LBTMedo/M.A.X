using UnityEngine;
using System.Collections;

public class Kamera : MonoBehaviour
{
    public float glasnost;
    private AudioSource source;
    public AudioClip[] back;
    public Transform player;
    public float damping = 1;
    public float GledajeNaprejFaktor = 1;
    public float VracanjeKamereHitrost = 15f;
    public float PragKamere = 0.0000001f;
    public float premikPoY = 0f;
    private float pozicijaY;
    private bool pogled = false;
    private bool upNdownNewBalance = true;
    private GameObject obj;
    float offsetZ;
    Vector3 ZadnjaPozicija;
    Vector3 Hitrost;
    Vector3 NaslednjaPozicija;
    // Use this for initialization
    void Start()
    {

        source = GetComponent<AudioSource>();
        int rand = Random.Range(0, back.Length);
        source.clip = back[0];
        source.volume = GameControl.control.MASTER * GameControl.control.MUSIC;
        source.Play();
        ZadnjaPozicija = player.position;
        pozicijaY = (transform.position - player.position).y;
        offsetZ = (transform.position - player.position).z;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        float xMoveDelta = (player.position - ZadnjaPozicija).x;
        bool GledanjeNaprej = Mathf.Abs(xMoveDelta) > PragKamere;
        if (GledanjeNaprej)
        {
            NaslednjaPozicija = GledajeNaprejFaktor * Vector3.right * Mathf.Sign(xMoveDelta);
        }
        else
        {
            NaslednjaPozicija = Vector3.MoveTowards(NaslednjaPozicija, Vector3.zero, Time.deltaTime * VracanjeKamereHitrost);
        }
        if (pogled == false)
        {
            NaslednjaPozicija.y = pozicijaY + premikPoY;
            Vector3 nextPozicija = player.position + NaslednjaPozicija + Vector3.forward * offsetZ;
            Vector3 novaPozicija = Vector3.SmoothDamp(transform.position, nextPozicija, ref Hitrost, damping);
            transform.position = novaPozicija;
            ZadnjaPozicija = player.position;
        }
        else
        {
            if (upNdownNewBalance == true)
            {
                NaslednjaPozicija.y = pozicijaY - 10f;
                Vector3 nextPozicija = player.position + NaslednjaPozicija + Vector3.forward * offsetZ;
                Vector3 novaPozicija = Vector3.SmoothDamp(transform.position, nextPozicija, ref Hitrost, damping);
                transform.position = novaPozicija;
                ZadnjaPozicija = player.position;
            }
            else
            {
                NaslednjaPozicija.y = pozicijaY + 3.5f;
                Vector3 nextPozicija = player.position + NaslednjaPozicija + Vector3.forward * offsetZ;
                Vector3 novaPozicija = Vector3.SmoothDamp(transform.position, nextPozicija, ref Hitrost, damping);
                transform.position = novaPozicija;
                ZadnjaPozicija = player.position;
            }
        }
    }
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            upNdownNewBalance = true;
            pogled = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            pogled = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            upNdownNewBalance = false;
            pogled = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            pogled = false;
        }
    }
}