using UnityEngine;
using System.Collections;

public class WaterController : MonoBehaviour {

    public float speed = 5f;
    public float floatspeed = 3f;

    public bool disabled = true;
    private bool facingRight;
    private Vector3 currentScale;

    private IgralecKontroler kontroler;
    private Rigidbody2D rbd;
	// Use this for initialization
	void Start () {
        kontroler = GetComponent<IgralecKontroler>();
        rbd = GetComponent<Rigidbody2D>();
        currentScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (!disabled)
        {
            Debug.Log("WaterKontroller");
            kontroler.disabled = true;

            if (Input.GetKey(KeyCode.Space))
            {
                rbd.velocity = new Vector2(rbd.velocity.x, floatspeed);
                Debug.Log("Floating");
            }

            rbd.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, rbd.velocity.y);

            if (Input.GetAxis("Horizontal") == -1)
            {
                facingRight = false;
            }

            if (Input.GetAxis("Horizontal") == 1)
            {
                facingRight = true;
            }


        } 
	}

    void flip() //function to flip player left or right
    {
        if (facingRight)
        {
            transform.localScale = new Vector3(currentScale.x, currentScale.y, 1); //turn right ----> to spremni pol v 1.5, 1.5, 1
        }
        else if (!facingRight)
        {
            transform.localScale = new Vector3(-currentScale.x, currentScale.y, 1); //turn left -------> to spremni pol v obratno
        }
    }
}
