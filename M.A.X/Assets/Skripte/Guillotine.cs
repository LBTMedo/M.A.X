using UnityEngine;
using System.Collections;

public class Guillotine : MonoBehaviour {

    public GameObject blade;
    public Transform startMarker;
    public Transform endMarker;
    public float fallingSpeed;
    public float liftingSpeed;
    static float distanceDown;
    static float distanceUp;
    float compareDistance = 0;
    bool falling = true;

    void Start()
    {
        distanceDown = endMarker.position.y;
        distanceUp = startMarker.position.y;
    }

    void FixedUpdate()
    {
        compareDistance = blade.transform.position.y;
        if (falling)
        {
            float d = Time.deltaTime * fallingSpeed;
            compareDistance -= d;
            if (compareDistance > distanceDown)
            {
                blade.transform.Translate(0, -d, 0);
            }
            else
            {
               // Debug.Log("y blada: " + compareDistance + " y endpoint: " + distanceDown);
                falling = false;
              
            }
        }
        else if (!falling)
        {
            float d = Time.deltaTime * liftingSpeed;
            compareDistance += d;
            if (compareDistance < distanceUp)
            {
                blade.transform.Translate(0, d, 0);
            }
            else
            {
                //Debug.Log("y blada: " + compareDistance + " y startpoint: " + distanceUp);
                falling = true;
             
            }
        }
    }

}
