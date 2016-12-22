using UnityEngine;
using System.Collections;

public class MoveWithTranslate : MonoBehaviour {

    public float speed;
    public bool leftOrRight = true;
    public bool left = true;
    public bool upOrDown = false;
    public bool up = true;

	void FixedUpdate()
    {
        if (leftOrRight)
        {
            Debug.Log("left or right");
            if (left)
                transform.Translate(-(Vector3.right * speed));
            else
                transform.Translate(Vector3.right * speed);
        }
        else if (upOrDown)
        {
            Debug.Log("up or down");
            if (up)
                transform.Translate((Vector3.up*speed));
            else
                transform.Translate(-(Vector3.up * speed));
        }
    }
}
