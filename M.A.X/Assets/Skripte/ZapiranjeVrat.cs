using UnityEngine;
using System.Collections;

public class ZapiranjeVrat : MonoBehaviour
{
    public GameObject OdpriVrata;
    public GameObject ZapriVrata;
    private int Entered = 0;
   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Entered == 0)
        {
            OdpriVrata.transform.Translate(Vector3.forward * Time.deltaTime * 90);
            OdpriVrata.transform.Translate(Vector3.up * Time.deltaTime * 90, Space.World);
            ZapriVrata.transform.Translate(Vector3.forward * Time.deltaTime * 90);
            ZapriVrata.transform.Translate(Vector3.down * Time.deltaTime * 90, Space.World);
            
            Entered = 1;
        }
        else
        {
            OdpriVrata.transform.Translate(Vector3.forward * Time.deltaTime * 90);
            OdpriVrata.transform.Translate(Vector3.down * Time.deltaTime * 90, Space.World);
            ZapriVrata.transform.Translate(Vector3.forward * Time.deltaTime * 90);
            ZapriVrata.transform.Translate(Vector3.up * Time.deltaTime * 90, Space.World);
            Entered = 0;
        }

    }
}
