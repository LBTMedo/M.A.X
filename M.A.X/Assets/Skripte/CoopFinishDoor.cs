using UnityEngine;
using System.Collections;

public class CoopFinishDoor : MonoBehaviour {

    CoopFinish finish;
    public bool prvi;
    public bool drugi;

    void Start()
    {
        finish = GetComponentInParent<CoopFinish>();
    }

    void OnTriggerEnter2D()
    {
        if (prvi)
        {
            Debug.Log("prvi");
            finish.SetPrvi(true);
        }
        else
        {
            Debug.Log("drugi");
            finish.SetDrugi(true);
        }
    }

    void OnTriggerExit2D()
    {
        if (prvi)
        {
            Debug.Log("prvi out");
            finish.SetPrvi(false);
        }
        else
        {
            finish.SetDrugi(false);
        }
    }
}
