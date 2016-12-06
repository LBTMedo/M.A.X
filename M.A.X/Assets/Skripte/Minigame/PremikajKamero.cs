using UnityEngine;
using System.Collections;

public class PremikajKamero : MonoBehaviour {

    private float zoomSpeed = 2.0f;

    public float KameraXObc = 100.0f;
    public float KameraYObc = 100.0f;


    private float speed = 3.0f;
    private float scroll = 5f;
    void Update()
    {
        scroll += -Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize = scroll * zoomSpeed;

        if (Input.GetMouseButton(1))
        {

            float rotationX = Input.GetAxis("Mouse X") * KameraXObc * Time.deltaTime;
            float rotationY = Input.GetAxis("Mouse Y") * KameraYObc * Time.deltaTime;
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
