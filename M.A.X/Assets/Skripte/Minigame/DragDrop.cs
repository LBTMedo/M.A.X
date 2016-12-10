using UnityEngine;
using System.Collections;

public class DragDrop : MonoBehaviour {

    private Vector3 dragPosition;
    // Use this for initialization
  //  private float rotationX = 0f, rotationY = 0f;
    public bool JeKlikjena = false;
    void Start()
    {

    }

    void OnMouseDown()
    {

    }
    void OnMouseDrag()
    {
        dragPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        dragPosition = Camera.main.ScreenToWorldPoint(dragPosition);
        dragPosition.z = 0.0f;
       // rotationX = Input.GetAxis("Mouse X") * 100f * Time.deltaTime;
       // rotationY = Input.GetAxis("Mouse Y") * 100f * Time.deltaTime;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            JeKlikjena = true;
            dragPosition = transform.position;

        }
        if (Input.GetMouseButtonUp(0))
            JeKlikjena = false;    
        if (JeKlikjena)
            transform.position = dragPosition;
    }
}
