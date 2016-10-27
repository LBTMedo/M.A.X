using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image fill;
	
	// Update is called once per frame
	void Update () {
        HandleBar();
	}

    private void HandleBar()
    {
        fill.fillAmount = fillAmount;  //tu bom uporabo funkcijo ConvertHealth
    }

    private float ConvertHealth(float currHealth, float healthMin, float healthMax, float scaleMin, float scaleMax)
    {
        return (currHealth - healthMin) * (scaleMax - scaleMin) / (healthMax - healthMin) + scaleMin;
    }
}
