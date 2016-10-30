using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private float fillAmount;

    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    private Image fill;

    [SerializeField]
    private Text healthValue;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            string[] tmp = healthValue.text.Split(':');
            healthValue.text = tmp[0] + ": " + value;
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
            fill.fillAmount = Mathf.Lerp(fill.fillAmount,fillAmount,Time.deltaTime * lerpSpeed);
        }
    }

    private float ConvertHealth(float currHealth, float healthMin, float healthMax, float scaleMin, float scaleMax)
    {
        return (currHealth - healthMin) * (scaleMax - scaleMin) / (healthMax - healthMin) + scaleMin;
    }
}
