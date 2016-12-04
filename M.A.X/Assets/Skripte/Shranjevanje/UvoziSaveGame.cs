using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;


public class UvoziSaveGame : MonoBehaviour {

     public Dropdown list;
	// Use this for initialization
	void Start () {
        list.options.Clear();
        string[] files = System.IO.Directory.GetFiles(Application.persistentDataPath+"/", "*.dat");       
        for (int i = 1; i < files.Length; i++)
        {
            string temp = Path.GetFileName(files[i]);
            temp = temp.Substring(0, temp.IndexOf("."));
            list.options.Add(new Dropdown.OptionData() { text = temp });
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
