using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Shop : MonoBehaviour {

    [SerializeField]
    private Text izpisCollider;

    [SerializeField]
    private Image shopBackground;

    [SerializeField]
    private Image[] slikeZaIteme;

  
   

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

    void LoadItemsAvailable(Image[] array)
    {
        List<GameObject> orozjaNaVoljo = new List<GameObject>();
        orozjaNaVoljo = WeaponManager.vrniVsaOrozja();
        for(int i=0; i<orozjaNaVoljo.Count;i++)
        {
            RocnoOrozje r = orozjaNaVoljo[i].GetComponent<RocnoOrozje>();
        
            
                if (array[i].tag == "Shop Item Background")
                {
                    Text[] arrayOfTexts = array[i].GetComponentsInChildren<Text>();
                    foreach (Text t in arrayOfTexts)
                    {
                        if (t.tag == "Shop Item Cost")
                        {
                            t.text = r.cena.ToString();
                            t.enabled = true;
                        }
                        else if(t.tag == "Shop Item Damage")
                        {
                            t.text = r.damage.ToString();
                            t.enabled = true;
                        }
                    }
                    array[i].enabled = true;
                    Image[] children = array[i].GetComponentsInChildren<Image>();
                    foreach(Image i1 in children)
                    {
                        i1.enabled = true;
                    }
                }

            
        }
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

    void startUpEnableDisableManager()
    {
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

                if (c.tag == "Shop Item" || c.tag == "Shop Item Background")
                {
                    c.enabled = false;
                    Text[] ary3 = c.GetComponentsInChildren<Text>();
                    foreach (Text t in ary3)
                    {
                        t.enabled = false;
                    }
                }
            }
            LoadItemsAvailable(slikeZaIteme);
        }
    }
	
	// Update is called once per frame
	void Update () {
        startUpEnableDisableManager();
    }

    
}
