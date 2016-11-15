using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    [SerializeField]
    private Text izpisCollider;

    [SerializeField]
    private Image shopBackground;
   

	// Use this for initialization
	void Start () {
        shopBackground.enabled = false;
        Image[] ary = shopBackground.GetComponentsInChildren<Image>();
        Button[] ary2 = shopBackground.GetComponentsInChildren<Button>();
        foreach (Button b in ary2)
        {
            b.enabled = false;
        }
        foreach (Image c in ary)
        {
            c.enabled = false;
            Text[] ary1 = c.GetComponentsInChildren<Text>();
            foreach(Text t in ary1)
            {
                t.enabled = false;
            }
        }
        izpisCollider.text = "";
        izpisCollider.fontSize = 14;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            izpisCollider.text = "Pritisni 'F' za nakup";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopBackground.enabled = false;
            Image[] ary = shopBackground.GetComponentsInChildren<Image>();
            Button[] ary2 = shopBackground.GetComponentsInChildren<Button>();
            foreach(Button b in ary2)
            {
                b.enabled = false;
            }
            foreach (Image c in ary)
            {
                c.enabled = false;
                Text[] ary1 = c.GetComponentsInChildren<Text>();
                foreach (Text t in ary1)
                {
                    t.enabled = false;
                }
            }
            izpisCollider.text = "";
            izpisCollider.fontSize = 14;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            shopBackground.enabled = true;
            Image[] ary = shopBackground.GetComponentsInChildren<Image>();
            Button[] ary2 = shopBackground.GetComponentsInChildren<Button>();
            foreach (Button b in ary2)
            {
                b.enabled = true;
            }
            foreach (Image c in ary)
            {
                c.enabled = true;
                Text[] ary1 = c.GetComponentsInChildren<Text>();
                foreach (Text t in ary1)
                {
                    t.enabled = true;
                }
            }
        }
    }
}
