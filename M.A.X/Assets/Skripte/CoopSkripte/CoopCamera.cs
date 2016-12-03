using UnityEngine;
using System.Collections;

public class CoopCamera : MonoBehaviour {

    public Transform igralec1, igralec2;
    public float minSizeY = 5f;

    void SetCameraPos()
    {
        Vector3 middle = (igralec1.position + igralec2.position) * 0.5f;

        GetComponent<Camera>().transform.position = new Vector3(middle.x, middle.y, GetComponent<Camera>().transform.position.z);
    }

    void SetCameraSize()
    {
        float minSizeX = minSizeY * Screen.width / Screen.height;

        float width = Mathf.Abs((igralec1.position.x) - (igralec2.position.x)) * 0.5f;
        float height = Mathf.Abs(igralec1.position.y - igralec2.position.y) * 0.5f;

        float camSizeX = Mathf.Max(width, minSizeX);
        GetComponent<Camera>().orthographicSize = Mathf.Max(height, camSizeX * Screen.height / Screen.width, minSizeY)+2;
    }
	
	// Update is called once per frame
	void Update () {
        SetCameraPos();
        SetCameraSize();
	}
}
