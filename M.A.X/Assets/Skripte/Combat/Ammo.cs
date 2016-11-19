using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ammo : MonoBehaviour {

    public int stMetkov;
    int startAmmoCount = 20;
    Igralec_borba igralec;

    public Text ammoText;

    public int[] metki;

    void Start()
    {
        igralec = FindObjectOfType<Igralec_borba>();
        metki = new int[igralec.vrsteMetkov.Length];
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
