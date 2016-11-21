using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZvokMaster : MonoBehaviour {

    private float vrednost;
    public Slider mainSlider;
    void Start()
    {
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
    public void ValueChangeCheck()
    {
        vrednost = mainSlider.value;
  
    }

}
