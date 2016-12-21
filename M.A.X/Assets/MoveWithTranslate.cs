using UnityEngine;
using System.Collections;

public class MoveWithTranslate : MonoBehaviour {

    public float speed;
    public bool left = true;

	void FixedUpdate()
    {
        if (left)
            transform.Translate(Time.deltaTime*speed, 0, 0);
        else
            transform.Translate(-(Time.deltaTime * speed), 0, 0);
    }
}
