using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AmmoCoop2 : MonoBehaviour {

    public int stMetkov;
    int startAmmoCount = 20;
    Igralec2_borba igralec2;

    public Text ammoText;

    public int[] metki;

    void Start()
    {
        igralec2 = FindObjectOfType<Igralec2_borba>();
        metki = new int[igralec2.vrsteMetkov.Length];
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
