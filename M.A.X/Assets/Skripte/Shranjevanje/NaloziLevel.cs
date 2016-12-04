using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NaloziLevel : MonoBehaviour {
    public Dropdown dr;
    public GameObject labela;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnClick()
    {
        
    int a = dr.value;
        string tekst = labela.GetComponent<Text>().text.ToString();
        GameControl.control.savegameIme = tekst;
        GameControl.control.Load();
    }
   
}
