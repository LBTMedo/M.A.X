using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UICoinCounter : MonoBehaviour {

    Text coinAmount;
    int startAmount;

	// Use this for initialization
	void Start () {
        coinAmount = GetComponent<Text>();
        coinAmount.text = GameControl.control.denar.ToString();
        startAmount = GameControl.control.denar;
	}
	
	// Update is called once per frame
	void Update () {
	    if(startAmount != GameControl.control.denar)
        {
            coinAmount.text = GameControl.control.denar.ToString();
            startAmount = GameControl.control.denar;
        }
	}
}
