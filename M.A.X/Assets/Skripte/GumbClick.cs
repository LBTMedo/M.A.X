using UnityEngine;

using System.Collections;
using UnityEngine.UI;

public class GumbClick : MonoBehaviour {
    private float master = 0.5f,sfxa = 0.5f;
    public AudioClip zvok;
    private AudioSource source;
    public Slider Master;
    public Slider SFX;
    // Use this for initialization
    void Start () {

        source = GetComponent<AudioSource>();
        source.PlayOneShot(zvok, master* sfxa);
	}
	
	// Update is called once per frame
	void Update () {
        if (master != Master.value)
        {
            master = Master.value;
            source.volume = master * sfxa;
        }
        if (sfxa != SFX.value)
        {
            sfxa = SFX.value;
            source.volume = master * sfxa;
        }
    }
}
