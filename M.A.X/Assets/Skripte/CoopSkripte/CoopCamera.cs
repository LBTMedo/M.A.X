using UnityEngine;
using System.Collections;

public class CoopCamera : MonoBehaviour {

    public Transform igralec1, igralec2;
    public float minSizeY = 5f;
    Igralec1 p1;
    Igralec2 p2;

    private AudioSource source;
    public AudioClip[] backGroundMusic;

    void Start()
    {
        p1 = FindObjectOfType<Igralec1>();
        p2 = FindObjectOfType<Igralec2>();
        source = GetComponent<AudioSource>();
        source.clip = backGroundMusic[0];
        source.volume = GameControl.control.MASTER * GameControl.control.MUSIC;
        source.Play();
    }

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
        if (p1.trenutnaZivljenja > 0 && p2.trenutnaZivljenja > 0)
        {
            SetCameraPos();
            SetCameraSize();
        }
	}
}
