using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public bool right = true;
    public bool rotate = true;
    public float rotationSpeed = 15f;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (rotate)
        {
            if (right)
            {
                transform.Rotate(Vector3.forward * rotationSpeed);
            }
            if (!right)
            {
                transform.Rotate(Vector3.back * rotationSpeed);
            }
        }
	}
}
