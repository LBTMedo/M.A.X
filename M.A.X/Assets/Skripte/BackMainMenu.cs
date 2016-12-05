using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackMainMenu : MonoBehaviour {
    public AudioClip[] zvokBack;
    private AudioSource source;
    public Slider obj;
    public Slider obj1;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        int rand = Random.Range(0, zvokBack.Length);
        source.clip = zvokBack[rand];
        source.volume = GameControl.control.MASTER*GameControl.control.MUSIC;
        source.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameControl.control.MASTER != obj.value)
        {
            
            GameControl.control.MASTER = obj.value;
            Debug.Log("spremeni0");
           source.volume = GameControl.control.MASTER * GameControl.control.MUSIC;
        }
        if (GameControl.control.MUSIC != obj1.value)
        {
            Debug.Log("spremeni1");
            GameControl.control.MUSIC = obj1.value;
            source.volume = GameControl.control.MASTER * GameControl.control.MUSIC;
        }
       

    }
}
