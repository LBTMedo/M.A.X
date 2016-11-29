using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

    public Sprite OpenSprite;
    private SpriteRenderer renderer;
    public GameObject trigger;
    private bool open = false;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        open = trigger.GetComponent<DoorTrigger1>().entered;
        if (open)
        {
            renderer.sprite = OpenSprite;
        }
	}
}
