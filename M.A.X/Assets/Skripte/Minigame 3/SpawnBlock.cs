using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnBlock : MonoBehaviour {
    public  GameObject[] SolidFloor;
    public  GameObject[] FloatingFloor;
    // Use this for initialization
    int stevec = 0;
   void Update() {

        if (Input.GetMouseButtonDown(0))
        {
            if (Settings.Nacin == 2)
            {
                Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                GameObject objekt = Instantiate(SolidFloor[0], new Vector3(clickPosition.x, clickPosition.y, 0), Quaternion.identity) as GameObject;
                objekt.name = "New" + stevec;
                stevec++;
            }
            
        }
    }
     
}
