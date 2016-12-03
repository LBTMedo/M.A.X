using UnityEngine;
using System.Collections;

public class LeverDoor : MonoBehaviour {

    private bool odprto1 = false;
    private bool odprto2 = false;

    public bool dvaGumba = false;

    Vector3 closedPos;
    Vector3 openPos;
    public float premikHorizontalno;
    public float premikVertikalno;

    void Start()
    {
        closedPos = transform.position;
        openPos = new Vector3(closedPos.x - premikHorizontalno, closedPos.y - premikVertikalno, closedPos.z);
    }

    public void SetOdprto(bool value)
    {
        odprto1 = value;
    }
    public bool GetOdprto()
    {
        return odprto1;
    }

    void OpenDoor()
    {
        transform.position = openPos;
    }

    void CloseDoor()
    {
        transform.position = closedPos;
    }

    public void SetOdprto2(bool value)
    {
        odprto2 = value;
    }

    public bool GetOdprto2()
    {
        return odprto2;
    }

    void Update()
    {
        if (dvaGumba == false)
        {
            if (odprto1 == true)
            {
                OpenDoor();
            }
            else if (odprto1 == false)
            {
                CloseDoor();
            }
        }
        else
        {
            if (odprto1 && odprto2)
            {
                OpenDoor();
            }
            else if (!odprto1 && !odprto2)
            {
                CloseDoor();
            }
        }
    }
}
