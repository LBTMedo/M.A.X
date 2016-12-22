using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lever : MonoBehaviour {

    [SerializeField]
    private LeverDoor slideDoor;
    [SerializeField]
    private MedievalDoor mDoor;

    [SerializeField]
    Sprite activated;
    [SerializeField]
    Sprite deactivated;

    SpriteRenderer slikaLever;

    bool entered = false;
    public bool medievalDoor = false;

    void Start()
    {
        slikaLever = GetComponent<SpriteRenderer>();
    }

	void OnTriggerEnter2D()
    {
        entered = true;
    }
    void OnTriggerExit2D()
    {
        entered = false;
    }

    void Update()
    {
        if(entered == true)
        {
            if (!medievalDoor)
            {
                if (Input.GetKeyDown(KeyCode.F) && slideDoor.GetOdprto() == false)
                {
                    slideDoor.SetOdprto(true);
                    slikaLever.sprite = activated;
                }
                else if (Input.GetKeyDown(KeyCode.F) && slideDoor.GetOdprto() == true)
                {
                    slideDoor.SetOdprto(false);
                    slikaLever.sprite = deactivated;
                }
            }
            else if (medievalDoor)
            {
                if (Input.GetKeyDown(KeyCode.F) && mDoor.GetOdprto() == false)
                {
                    mDoor.SetOdprto(true);
                    mDoor.SetFirstTimeRotated(true);
                    slikaLever.sprite = activated;
                }
                else if (Input.GetKeyDown(KeyCode.F) && mDoor.GetOdprto() == true)
                {
                    mDoor.SetOdprto(false);
                    mDoor.SetFirstTimeRotated(true);
                    slikaLever.sprite = deactivated;
                }
            }
        }
    }

}
