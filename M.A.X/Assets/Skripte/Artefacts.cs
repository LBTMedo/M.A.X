using UnityEngine;
using System.Collections;

public class Artefacts : MonoBehaviour {

    public static int NumberOfArtefacts = 3;
    public bool[] artefacts;
    public bool full = false;
    private int count;
	// Use this for initialization
	void Start () {
         artefacts = new bool[NumberOfArtefacts];
    }
	
	// Update is called once per frame
	void Update () {
        count = 0;
	    for (int i = 0; i < NumberOfArtefacts; i++)
        {
            if (artefacts[i] == true)
            {
                count++;
            }
        }
        if (count == NumberOfArtefacts)
            full = true;
	}
}
