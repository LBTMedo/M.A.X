using UnityEngine;
using System.Collections;

public class MovingPlatforms : MonoBehaviour {

    public Transform end;
    private Vector3 endpos;
    private Vector3 start;
    private float speed = 1f;
    public float moveTime = 1f;
    private float pingpong;
	// Use this for initialization
	void Start () {
        start = transform.position;
        endpos = end.position;
    }
	
	// Update is called once per frame
	void Update () {
        pingpong = Mathf.PingPong(Time.time * speed / moveTime, 1f);
        
        transform.position = Vector3.Lerp(start, endpos, Mathf.SmoothStep(0f, 1f, pingpong));
        transform.position = Vector3.Lerp(endpos, start, Mathf.SmoothStep(0f, 1f, pingpong));

    }
}
