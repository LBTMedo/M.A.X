using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Prilagodi : MonoBehaviour
{
    public Slider sliderMV;
    public Slider sliderSFX;
    public Slider sliderBACK;
    private float MV = 0.5f, SFX = 0.5f, BACK = 0.5f;

    void Update()
    {
        if (MV != sliderMV.value)
        {
            GameControl.control.MASTER = sliderMV.value;
        }

        if (SFX != sliderSFX.value)
        {
            GameControl.control.SFX = sliderSFX.value;
        }

        if (BACK != sliderBACK.value)
        {
            GameControl.control.MUSIC = sliderBACK.value;;
        }

    }
}
