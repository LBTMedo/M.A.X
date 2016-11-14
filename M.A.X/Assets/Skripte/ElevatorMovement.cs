using UnityEngine;
using System.Collections;

public class ElevatorMovement: MonoBehaviour {

    public Transform end;
    private Vector3 endpos;
    private Vector3 start;
    private float speed = 1f;
    private float pingpong;
	// Use this for initialization
	void Start () {
        endpos = end.position;
        start = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	    pingpong = Mathf.PingPong(Time.time * speed, 1f);
	}

    void OnTriggerEnter(Collider2D other)
    {
        if (other.tag == "Igralec")
        {
            transform.position = Vector3.Lerp(start, endpos, Mathf.SmoothStep(0f, 1f, pingpong));
            transform.position = Vector3.Lerp(endpos, start, Mathf.SmoothStep(0f, 1f, pingpong));

        }
    }
}
