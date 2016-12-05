using UnityEngine;
using System.Collections;

public class BossDoor : MonoBehaviour {

    public bool open;
    private Animator anim;
    bool entered = false;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
       
            if (open)
            {
                Debug.Log("Opening boss door");
                anim.SetBool("open", true);
                
                entered = true;
            }
        
	}
    void OnTriggerEnter2D()
    {
        if (entered == false)
        {
            GameControl.control.LoadNextLevel();
        }
    }
}
