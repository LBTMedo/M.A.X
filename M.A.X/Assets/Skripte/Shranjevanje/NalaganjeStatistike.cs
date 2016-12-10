using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NalaganjeStatistike : MonoBehaviour {
    public Text smrti;
    public Text Uboji;
    public Text cas;
    public Text denar;
    public Text single;
    public Text coop;

    // Use this for initialization
    void Start () {
        smrti.text = GameControl.control.smrti.ToString();
        Uboji.text = GameControl.control.ubitiSovrazniki.ToString();
        cas.text = GameControl.control.cas.ToString();
        denar.text = GameControl.control.denar.ToString();
        single.text = GameControl.control.SingleGameProgress.ToString();
        coop.text = GameControl.control.CooPGameProgress.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
