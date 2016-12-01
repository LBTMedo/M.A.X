using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lever : MonoBehaviour {

    [SerializeField]
    private Text reminder;

    [SerializeField]
    private LeverDoor slideDoor;

    [SerializeField]
    Sprite activated;
    [SerializeField]
    Sprite deactivated;

    SpriteRenderer slikaLever;

    bool entered = false;

    void Start()
    {
        slikaLever = GetComponent<SpriteRenderer>();
    }

	void OnTriggerEnter2D()
    {
        //reminder.text = "press 'F'";
        entered = true;
    }
    void OnTriggerExit2D()
    {
        //reminder.text = "";
        entered = false;
    }

    void Update()
    {
        if(entered == true)
        {
            if (Input.GetKeyDown(KeyCode.F) && slideDoor.GetOdprto() == false)
            {
                slideDoor.SetOdprto(true);
                slikaLever.sprite = activated;
            }
            else if(Input.GetKeyDown(KeyCode.F) && slideDoor.GetOdprto() == true)
            {
                slideDoor.SetOdprto(false);
                slikaLever.sprite = deactivated;
            }
        }
    }

}
