using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShraniIgro : MonoBehaviour {
    bool entered = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (entered == false)
        {

            GameControl.control.currentLevel += 1;
            GameControl.control.Save();
            GameControl.control.SaveDefault();
            SceneManager.LoadScene(GameControl.control.currentLevel);
            entered = true;
        }
    }
}
