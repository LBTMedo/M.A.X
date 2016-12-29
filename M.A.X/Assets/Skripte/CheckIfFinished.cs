using UnityEngine;
using System.Collections;

public class CheckIfFinished : MonoBehaviour {

    bool entered = false;
    Artefacts pieces;

	// Use this for initialization
	void Start () {
        pieces = FindObjectOfType<Artefacts>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            entered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            entered = false;
        }
    }

    // Update is called once per frame
    void Update () {
        if (entered)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (pieces.full)
                {
                    Debug.Log("All artefacts collected.");
                }
            }
        }
	}
}
