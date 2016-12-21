using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {

    static List<GameObject> vsaOrozja;

    static List<GameObject> orozja;
    static int trenutnoOrozje;

    void Start()
    {
        orozja = new List<GameObject>();
        vsaOrozja = new List<GameObject>();

        foreach(Transform child in transform)
        {
            vsaOrozja.Add(child.gameObject);
            orozja.Add(child.gameObject);//TESTIRANJE
        }

        foreach (GameObject orozje in vsaOrozja)
        {
            orozje.SetActive(false);
        }

        foreach (GameObject orozje in orozja)//TESTIRANJE
        {
            orozje.SetActive(false);
        }

        //vsaOrozja[trenutnoOrozje].SetActive(true); //TESTIRANJE
    }

    public static List<GameObject> vrniVsaOrozja()
    {
        return vsaOrozja;
    }

    public static List<GameObject> vrniKupljenaOrozja()
    {
        return orozja;
    }

    public static Transform VrniTrenutnoOrozje()
    {
        return vsaOrozja[trenutnoOrozje].transform;
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

    public static int stOrozij()
    {
        //return orozja.Count;
        return 1;
    }

    public static void kupiOrozje(int index)
    {
        orozja.Add(vsaOrozja[index]);
    }
}