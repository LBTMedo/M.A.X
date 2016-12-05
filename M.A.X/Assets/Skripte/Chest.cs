using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

    public Sprite OpenSprite;
    private SpriteRenderer renderer;
    public GameObject drop;
    public GameObject trigger;
    private int count = 0;
    private bool open = false;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        open = trigger.GetComponent<DoorTrigger>().entered;
        if (open && count == 0)
        {
            renderer.sprite = OpenSprite;
            Instantiate(drop, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation);
            count++;
        }
	}
}
