using UnityEngine;

using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider mainSlider;

    //Invoked when a submit button is clicked.
    public void SubmitSliderSetting()
    {
        //Displays the value of the slider in the console.
        Debug.Log(mainSlider.value);
    }
}