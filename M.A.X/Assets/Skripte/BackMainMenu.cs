using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackMainMenu : MonoBehaviour {
    public AudioClip[] zvokBack;
    private AudioSource source;
    public Slider obj;
    public Slider obj1;
    float musicSlider = 0.5f;
    float glastnost = 0.5f;
    // Use this for initialization
    void Start () {
      
        source = GetComponent<AudioSource>();
        int rand = Random.Range(0, zvokBack.Length);
        source.clip = zvokBack[rand];
        source.volume = glastnost;
        source.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (glastnost != obj.value)
        {
           glastnost = obj.value;
           source.volume = glastnost*musicSlider;
        }
        if (musicSlider != obj1.value)
        {
            musicSlider = obj1.value;
            source.volume = glastnost * musicSlider;
        }
       

    }
}
