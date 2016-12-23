using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnBlock : MonoBehaviour
{
    public GameObject[] SolidFloor;
    public GameObject[] FloatingFloor;
    // Use this for initialization
    int stevec = 0;


    void Update()
    {
        if (NedovoliPostavljat.IsValid == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Settings.Nacin == 2)
                {
                  
                        if (Settings.ZamenjajTip == 1)
                        {
                            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            GameObject objekt = Instantiate(SolidFloor[ChangeBlocks.Block], new Vector3(clickPosition.x, clickPosition.y, 0), Quaternion.identity) as GameObject;
                            objekt.name = "New" + stevec;
                            stevec++;
                        }
                        else if (Settings.ZamenjajTip == 2)
                        {
                            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            GameObject objekt = Instantiate(FloatingFloor[ChangeBlocks.Block], new Vector3(clickPosition.x, clickPosition.y, 0), Quaternion.identity) as GameObject;
                            objekt.name = "New" + stevec;
                            stevec++;
                        }
                      
                }

            }
        }
    }
   

}
