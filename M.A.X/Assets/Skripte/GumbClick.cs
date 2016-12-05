using UnityEngine;

using System.Collections;
using UnityEngine.UI;

public class GumbClick : MonoBehaviour {
    public AudioClip zvok;
    private AudioSource source;
    public Slider Master;
    public Slider SFX;
    // Use this for initialization
    void Start () {
     
        source = GetComponent<AudioSource>();
        source.PlayOneShot(zvok, GameControl.control.MASTER * GameControl.control.SFX);
	}
	
	// Update is called once per frame
	void Update () {
        if (GameControl.control.MASTER != Master.value)
        {
            GameControl.control.MASTER = Master.value;
            source.volume = GameControl.control.MASTER * GameControl.control.SFX;
        }
        if (GameControl.control.SFX != SFX.value)
        {
            GameControl.control.SFX = SFX.value;
            source.volume = GameControl.control.MASTER * GameControl.control.SFX;
        }
    }
}
