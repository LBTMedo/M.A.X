using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour {

    private void Start()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
