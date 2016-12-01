using UnityEngine;
using System.Collections;

public class LeverDoor : MonoBehaviour {

    private bool odprto = false;

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
        odprto = value;
    }
    public bool GetOdprto()
    {
        return odprto;
    }

    void OpenDoor()
    {
        transform.position = openPos;
    }

    void CloseDoor()
    {
        transform.position = closedPos;
    }

    void Update()
    {
        if(odprto == true)
        {
            OpenDoor();
        }
        else if(odprto == false)
        {
            CloseDoor();
        }
    }
}
