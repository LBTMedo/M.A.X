using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShraniIgro : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        GameControl.control.ubitiSovrazniki = 2;
        GameControl.control.denar = 350;
        GameControl.control.currentLevel = GameControl.control.currentLevel + 1;
        GameControl.control.Save();
        
        SceneManager.LoadScene(GameControl.control.currentLevel);
    }
}
