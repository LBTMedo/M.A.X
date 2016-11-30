using UnityEngine;
using System.Collections;

public class ZapiranjeVrat : MonoBehaviour
{
    public GameObject OdpriVrata;
    // public GameObject ZapriVrata;
    public bool gorDol = true;
    public int visina = 1;
    private int Entered = 0;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (gorDol)
        {
            if (Entered == 0)
            {

                OdpriVrata.transform.Translate(Vector3.up * Time.deltaTime * 90 * visina, Space.World);

                Entered = 1;
            }
            else
            {

                OdpriVrata.transform.Translate(Vector3.down * Time.deltaTime * 90 * visina, Space.World);
              
                Entered = 0;
            }
        }
        else
        {
            if (Entered == 0)
            {
                
                
                OdpriVrata.transform.Translate(Vector3.down * Time.deltaTime * 90 * visina, Space.World);
                Entered = 1;
            }
            else
            {

                OdpriVrata.transform.Translate(Vector3.up * Time.deltaTime * 90 * visina, Space.World);

                Entered = 0;
            }
        }


    }
}
