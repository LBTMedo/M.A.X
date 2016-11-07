using UnityEngine;
using System.Collections;

public class Kamera : MonoBehaviour {
    public Transform player;
    public float damping = 1;
    public float GledajeNaprejFaktor = 3;
    public float VracanjeKamereHitrost = 0.5f;
    public float PragKamere = 0.1f;

    float offsetZ;
    Vector3 ZadnjaPozicija;
    Vector3 Hitrost;
    Vector3 NaslednjaPozicija;
    // Use this for initialization
    void Start () {
        ZadnjaPozicija = player.position;
        offsetZ = (transform.position - player.position).z;
        transform.parent = null;
    }
	
	// Update is called once per frame
	void Update () {
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
        Vector3 nextPozicija = player.position + NaslednjaPozicija + Vector3.forward * offsetZ;
        Vector3 novaPozicija = Vector3.SmoothDamp(transform.position, nextPozicija, ref Hitrost, damping);
        transform.position = novaPozicija;
        ZadnjaPozicija = player.position;
    }
}
