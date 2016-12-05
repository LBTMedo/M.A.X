using UnityEngine;
using System.Collections;

public class Pendulum : MonoBehaviour {

    public float angle = 90f;
    public float speed = 20f;
    public Transform End;
    private Vector3 anchorpos;
    private bool right;
    public bool deactivated = true;
	// Use this for initialization
	void Start () {
        anchorpos = End.position;
        right = true;
	}

    // Update is called once per frame
    void Update()
    {
        if (!deactivated)
        {
            if (right)
            {
                transform.RotateAround(End.position, new Vector3(0, 0, 1), Time.deltaTime * speed);

                if (transform.rotation.z * 100 >= angle)
                {
                    right = false;
                    transform.RotateAround(End.position, new Vector3(0, 0, -1), Time.deltaTime * speed);
                }

            }
            else
            {

                transform.RotateAround(End.position, new Vector3(0, 0, -1), Time.deltaTime * speed);

                if (transform.rotation.z * 100 <= -angle)
                {
                    right = true;
                    transform.RotateAround(End.position, new Vector3(0, 0, 1), Time.deltaTime * speed);
                }
            }
        }
    }
}
