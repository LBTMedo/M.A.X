using UnityEngine;
using System.Collections;

public class PremikajKamero : MonoBehaviour {

    private float zoomSpeed = 2.0f;
    public static  bool click = false;
    public float KameraXObc = 100.0f;
    public float KameraYObc = 100.0f;


    private float speed = 3.0f;
    private float scroll = 5f;
    private float scrollcheck;
    private float sensitivity;
    void Update()
    {
        if (click == false)
        {
            scroll += -Input.GetAxis("Mouse ScrollWheel");
            if (scroll < 10 && (scroll > 1) )
            {
                scrollcheck = scroll;
                Camera.main.orthographicSize = scroll * zoomSpeed;
            }
            else if(scroll > 12)
            {
                scroll = scrollcheck;
            }          
            else if (scroll <1)
            {
                scroll = scrollcheck;
            }
            sensitivity = scroll / 10;
        }

        if (Input.GetMouseButton(1))
        {

            float rotationX = Input.GetAxis("Mouse X") * KameraXObc*sensitivity * Time.deltaTime;
            float rotationY = Input.GetAxis("Mouse Y") * KameraYObc * sensitivity * Time.deltaTime;
            transform.Translate(new Vector3(-rotationX, -rotationY, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
}
