using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image fill;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmount = ConvertHealth(value, 0, MaxValue, 0, 1);
        }
    }

    // Update is called once per frame
    void Update () {
        HandleBar();
	}

    private void HandleBar()
    {
        if (fillAmount != fill.fillAmount)
        {
            fill.fillAmount = fillAmount;
        }
    }

    private float ConvertHealth(float currHealth, float healthMin, float healthMax, float scaleMin, float scaleMax)
    {
        return (currHealth - healthMin) * (scaleMax - scaleMin) / (healthMax - healthMin) + scaleMin;
    }
}
