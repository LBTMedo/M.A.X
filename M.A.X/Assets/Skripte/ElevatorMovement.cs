using UnityEngine;
using System.Collections;

public class ElevatorMovement: MonoBehaviour {

    public Transform end;
    private Vector3 endpos;
    private Vector3 start;
    private float speed = 1f;
    private float pingpong;

    public float timeToMove = 5;

    public bool move = true;
    private bool moveBack;
    private bool isAtEnd;
	// Use this for initialization
	void Start () {
        endpos = end.position;
        start = transform.position;
        isAtEnd = false;
        moveBack = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (move)
        {
            pingpong = Mathf.PingPong(Time.time * speed / timeToMove, 1f);

            transform.position = Vector3.Lerp(start, endpos, Mathf.SmoothStep(0f, 1f, pingpong));
            transform.position = Vector3.Lerp(endpos, start, Mathf.SmoothStep(0f, 1f, pingpong));
        }

        /*if (move)
        {

            float pingpong = Mathf.PingPong(Time.time * speed / timeToMove, 1f);
            transform.position = Vector3.Lerp(start, endpos, Mathf.SmoothStep(0f, 1f, pingpong));
            if (pingpong >= 0.99f)
            {
                isAtEnd = true;
                move = false;
            }
        }
        else if (moveBack)
        {
            float pingpong = Mathf.PingPong(Time.time * speed / timeToMove, 1f);
            transform.position = Vector3.Lerp(endpos, start, Mathf.SmoothStep(0f, 1f, pingpong));
            if (pingpong >= 0.99f)
            {
                isAtEnd = false;
                move = false;
            }
        }*/
    }

    /*void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && !isAtEnd)
        {
            move = true;
            Debug.Log("Moving elevator.");
        }
        else if (other.tag == "Player" && isAtEnd)
        {
            moveBack = true;
        }
    }*/
}
