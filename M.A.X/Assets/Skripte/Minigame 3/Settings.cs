using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

    Text tekst;
    public static int Nacin = 1;
    public static int ZamenjajTip = 1;
    public void ClickChange()
    {
        tekst = GameObject.Find("Text123").GetComponent<Text>();

        if (Nacin < 3)
        {
            Nacin++;
            if (Nacin == 2)
            {
                tekst.text = "CREATE";

            }
            else if (Nacin == 3)
            {
                tekst.text = "DESTROY";

            }


        }
        else if (Nacin == 3)
        {
            Nacin = 1;
            tekst.text = "MOVE";
        }
        Debug.Log(Nacin);
    }
    public void ChangeBlockType()
    {
        tekst = GameObject.Find("TextType").GetComponent<Text>();

        if (ZamenjajTip < 2)
        {
            ZamenjajTip++;
            if (ZamenjajTip == 2)
            {
                tekst.text = "FLOAT BLOCKS";

            }
        }
        else if (ZamenjajTip == 2)
        {
            ZamenjajTip = 1;
            tekst.text = "SOLID BLOCKS";
        }
    }
}
