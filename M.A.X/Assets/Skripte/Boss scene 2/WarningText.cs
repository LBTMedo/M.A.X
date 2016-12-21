using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WarningText : MonoBehaviour {

    Text warning;
    public float blinkingTime;
    public int timesToBlink;
    public float TimeTillBlink;
    bool warningActive = false;

    public void SetWarning(bool value)
    {
        warningActive = value;
    }

    void Start()
    {
        warning = GetComponent<Text>();
        warning.enabled = false;
    }

    void Update()
    {
        if (warningActive)
        {
            StartCoroutine(Warn());
        }
    }

    IEnumerator Warn()
    {
        warningActive = false;
        yield return new WaitForSeconds(TimeTillBlink);
        for (int i = 0; i < timesToBlink; i++)
        {
            warning.enabled = true;
            yield return new WaitForSeconds(blinkingTime);
            warning.enabled = false;
            yield return new WaitForSeconds(blinkingTime);
        }
    }
}
