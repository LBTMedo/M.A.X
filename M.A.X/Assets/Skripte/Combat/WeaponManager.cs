using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {

    static List<GameObject> orozja;
    static int trenutnoOrozje;


    void Start()
    {
        orozja = new List<GameObject>();
        foreach(Transform child in transform)
        {
            orozja.Add(child.gameObject);
        }

        foreach(GameObject orozje in orozja)
        {
            orozje.SetActive(false);
        }

        orozja[trenutnoOrozje].SetActive(true);
    }

    public static Transform VrniTrenutnoOrozje()
    {
        return orozja[trenutnoOrozje].transform;
    }

    public static void ZamenjajOrozje()
    {
        trenutnoOrozje++;
        if (trenutnoOrozje == orozja.Count)
        {
            trenutnoOrozje = 0;
        }

        foreach (GameObject orozje in orozja)
        {
            orozje.SetActive(false);
        }

        orozja[trenutnoOrozje].SetActive(true);
    }
}
