using UnityEngine;
using System.Collections;

public class ButtonSetBool : MonoBehaviour {

    Vector3 defaultPos = new Vector3();
    Vector3 pushedPos;
    [SerializeField]
    LeverDoor vrata;
    public bool prvi;
    public bool drugi;
    bool disableOnTriggerExit = false;

    void Start()
    {
        defaultPos = transform.position;
        pushedPos = new Vector3(defaultPos.x, defaultPos.y - 0.20f, defaultPos.z);
    }

    void Update()
    {
        if (vrata.GetOdprto() && vrata.GetOdprto2())
        {
            disableOnTriggerExit = true;
        }
    }

    void OnTriggerEnter2D()
    {   
       
        if (prvi)
        {
            transform.position = pushedPos;
            vrata.SetOdprto(true);
        }
        else
        {
            transform.position = pushedPos;
            vrata.SetOdprto2(true);
        }
    }

    void OnTriggerExit2D()
    {
        if (!disableOnTriggerExit)
        {
            if (prvi)
            {
                transform.position = defaultPos;
                vrata.SetOdprto(false);
            }
            else
            {
                transform.position = defaultPos;
                vrata.SetOdprto2(false);
            }
        }
    }
}
