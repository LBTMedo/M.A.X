using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour {
    public Slider sliderMV;
    public Slider sliderSFX;
    public Slider sliderBACK;
    private float MV = 0.5f, SFX = 0.5f, BACK = 0.5f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(MV != sliderMV.value)
        {
            MV = sliderMV.value;
            Debug.Log(MV + " " + BACK + " " + SFX);
        }
           
        if (SFX != sliderSFX.value)
        {
            SFX = sliderSFX.value;
            Debug.Log(MV + " " + BACK + " " + SFX);
        }
            
        if (BACK != sliderBACK.value)
        {
            BACK = sliderBACK.value;
            Debug.Log(MV + " " + BACK + " " + SFX);
        }
            
        
    }
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
