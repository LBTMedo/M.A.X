using UnityEngine;
using System.Collections;

public class LogObstacle : MonoBehaviour {

    bool isUp = true;
    public float rotationAmount;
    Vector3 currPos = new Vector3();
    Vector3 rotatePos;
    bool isRot = false;

    void Start()
    {
        currPos = transform.position;
        rotatePos = new Vector3(currPos.x-2,currPos.y-2,currPos.z);
    }

    public void SetState(bool value)
    {
        isUp = value;
    }

    void Update()
    {
        if (!isUp)
        {
            transform.position = rotatePos;
            if (!isRot)
            {
                transform.Rotate(0, 0, 90);
                isRot = true;
            }
        }
        else
        {
            transform.position = currPos;
            if (isRot)
            {
                transform.Rotate(0, 0, -90);
                isRot = false;
            }
        }
    }
}
