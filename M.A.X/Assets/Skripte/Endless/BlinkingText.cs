using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour {

    Text tekst;
    string zacetniTekst;

    private void Start()
    {
        tekst = GetComponent<Text>();
        zacetniTekst = tekst.text;

        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            tekst.text = zacetniTekst;
            yield return new WaitForSeconds(0.5f);
            tekst.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
