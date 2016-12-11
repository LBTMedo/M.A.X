using UnityEngine;
using System.Collections;


public class DragDrop : MonoBehaviour
{
    private Vector3 LastLegitPosition;
    private Vector3 dragPosition;
    Transform trans;
    
    float scroll = 0.0f;
    public bool JeKlikjena = false;
    private bool once = false;
    void OnMouseDrag()
    {
        if (Settings.Nacin == 1)
        {
            dragPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            dragPosition = Camera.main.ScreenToWorldPoint(dragPosition);
            dragPosition.z = 0.0f;
            transform.Rotate(Vector3.forward * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel") * 600, Space.World);
        }
    }
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Settings.Nacin == 3)
            {
                Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hits = Physics2D.Raycast(clickPosition, clickPosition);


                if (hits != null && hits.collider != null)
                {
                    Destroy(GameObject.Find(hits.collider.gameObject.name));

                }

            }          
        }
    }


    void Update()
    {
        if (Settings.Nacin == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                JeKlikjena = true;

                dragPosition = this.transform.position;

            }
            if (Input.GetMouseButtonUp(0))
            {
                JeKlikjena = false;
                PremikajKamero.click = false;
            }
            if (JeKlikjena)
            {
                if (NedovoliPostavljat.IsValid == true)
                {
                     
                    this.transform.position = dragPosition;
                    LastLegitPosition = transform.position;
                    PremikajKamero.click = true;
                }
                else
                {
                    transform.position = LastLegitPosition;
                }
            }
        }





    }

}
