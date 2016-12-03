using UnityEngine;
using System.Collections;

public class SwingTrapRotation : MonoBehaviour {

    public float angleRange;
    public float speed;

    void Update()
    {

        transform.eulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * speed, angleRange) - angleRange / 2);

    }
}
