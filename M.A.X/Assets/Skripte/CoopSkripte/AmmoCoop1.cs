using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AmmoCoop1 : MonoBehaviour {

    public int stMetkov;
    int startAmmoCount = 20;
    Igralec1_borba igralec1;

    public Text ammoText;

    public int[] metki;

    void Start()
    {
        igralec1 = FindObjectOfType<Igralec1_borba>();
        metki = new int[igralec1.vrsteMetkov.Length];
        for (int i = 0; i < metki.Length; i++)
        {
            metki[i] = startAmmoCount;
        }

        ammoText.text = metki[0].ToString();
    }

    public void ZmanjsajSTMetkov(int ammount, int index)
    {
        metki[index] -= ammount;
        ammoText.text = metki[index].ToString();
    }

    public void PovecajSTMetkov(int ammount, int index)
    {
        metki[index] += ammount;
        ammoText.text = metki[index].ToString();
    }

    public void ZamenjajIndex(int index)
    {
        ammoText.text = metki[index].ToString();
    }
}
