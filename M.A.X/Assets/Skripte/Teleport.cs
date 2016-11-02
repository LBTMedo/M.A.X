using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour
{
    public Transform target;
    private bool odsel = false;
    void OnTriggerEnter2D(Collider2D coll)
    {
        odsel = false;
    }
    IEnumerator OnTriggerStay2D(Collider2D coll)
    {
        if (odsel == false)
        {
            yield return new WaitForSeconds(5);
            if (odsel == false)
                coll.transform.position = target.position;
        }
    } 
    void OnTriggerExit2D(Collider2D coll)
    {
        odsel = true;
        
    }
}
