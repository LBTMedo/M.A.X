using UnityEngine;
using System.Collections;

public class MedievalDoor : MonoBehaviour {

    Vector3 currPos;
    Vector3 openPos;
    BoxCollider2D coll;
    public Sprite odprtoS;
    public Sprite zaprtoS;
    SpriteRenderer spriteRend;
    bool odprto = false;
    bool firstTimeRotated = false;
    public bool playSound = false;
    public AudioClip doorSound;
    AudioSource source;

    public void SetOdprto(bool value)
    {
        odprto = value;
    }

    public void SetFirstTimeRotated(bool value)
    {
        firstTimeRotated = value;
    }

    public bool GetOdprto()
    {
        return odprto;
    }

	// Use this for initialization
	void Start () {
        if (playSound)
        {
            source = GetComponent<AudioSource>();
        }
        spriteRend = GetComponent<SpriteRenderer>();
        currPos = transform.position;
        openPos = new Vector3(currPos.x - 1.5f, currPos.y, currPos.z);
        coll = GetComponent<BoxCollider2D>();
	}

    void OpenDoor()
    {
        transform.position = openPos;
        spriteRend.sprite = odprtoS;
        transform.Rotate(0, 180, 0);
        coll.enabled = false;
        if (playSound)
        {
            source.PlayOneShot(doorSound, GameControl.control.MASTER * GameControl.control.SFX);
        }
    }

    void CloseDoor()
    {
        transform.position = currPos;
        transform.Rotate(0, 180, 0);
        spriteRend.sprite = zaprtoS;
        coll.enabled = true;
        if (playSound)
        {
            source.PlayOneShot(doorSound, GameControl.control.MASTER * GameControl.control.SFX);
        }
    }
	
	// Update is called once per frame
	void Update () {
	    if(odprto == true && firstTimeRotated == true)
        {
            OpenDoor();
            firstTimeRotated = false;
        }
        else if(odprto == false && firstTimeRotated == true)
        {
            CloseDoor();
            firstTimeRotated = false;
        }
	}
}
