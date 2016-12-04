using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NovaIgra : MonoBehaviour {

    public Text tekst;

     public void OnClikNewGame()
    {
        
        string temp = tekst.text;
        Debug.Log(temp);
        GameControl.control.savegameIme = temp;
        GameControl.control.currentLevel = 1;
        GameControl.control.Save();
        GameControl.control.Load();
    }
}
