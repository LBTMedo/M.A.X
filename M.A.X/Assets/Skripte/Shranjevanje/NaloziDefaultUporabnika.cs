using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NaloziDefaultUporabnika : MonoBehaviour {
    public Text tekst;
	// Use this for initialization
    public static bool spremeniUporabnika = false;
	void Start () { 
        tekst.text = GameControl.control.LoadDefault();
	}
	
	// Update is called once per frame
	void Update () {
        if (tekst.text != GameControl.control.LoadDefault())
        {
            tekst.text = GameControl.control.LoadDefault();
        }
	}
    void SpremeniUporabnika()
    {
        
    }
}
