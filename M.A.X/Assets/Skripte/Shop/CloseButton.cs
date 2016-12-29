using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour {

    [SerializeField]
    Image shopBackground;

    Button gumbZapri;

	// Use this for initialization
	void Start () {
        gumbZapri = GetComponent<Button>();
        gumbZapri.onClick.AddListener(CloseShopInterface);
	}

    void CloseShopInterface()
    {
        shopBackground.enabled = false;
        Image[] ary = shopBackground.GetComponentsInChildren<Image>();
        Button[] ary1 = shopBackground.GetComponentsInChildren<Button>();

        foreach(Button b in ary1)
        {
            b.enabled = false;
        }
        foreach(Image c in ary)
        {
            c.enabled = false;
            Text[] ary2 = c.GetComponentsInChildren<Text>();
            foreach(Text t in ary2)
            {
                t.enabled = false;
            }
        }
    }
	
	
}
