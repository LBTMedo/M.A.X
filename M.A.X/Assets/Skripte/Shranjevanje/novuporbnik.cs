using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class novuporbnik : MonoBehaviour {
    public Text tekst;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnclickSave()
    {
        GameControl.control.savegameIme = tekst.text;
        GameControl.control.Save();
        GameControl.control.SaveDefault();

    }
}
