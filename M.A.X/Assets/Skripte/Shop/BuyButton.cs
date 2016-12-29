using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuyButton : MonoBehaviour {

   
    private int ind = -1;
    Shop trgovina;
    List<GameObject> orozjaNaVoljo;
    List<GameObject> kupljenaOrozja;
    GameManager gm;

    void Start()
    {
        trgovina = FindObjectOfType<Shop>();
        orozjaNaVoljo = WeaponManager.vrniVsaOrozja();
        gm = FindObjectOfType<GameManager>();
    }

    public void SetInd(int n)
    {
        ind = n;
    }

    public void Kupi()
    {
        if (ind != -1)
        {
            RocnoOrozje r = orozjaNaVoljo[ind].GetComponent<RocnoOrozje>();
            bool alreadyOwned = false;
            kupljenaOrozja = new List<GameObject>();
            kupljenaOrozja = WeaponManager.vrniKupljenaOrozja();
            foreach(GameObject g in kupljenaOrozja)
            {
                RocnoOrozje r1 = g.GetComponent<RocnoOrozje>();
                if(r1.ime == r.ime)
                {
                    alreadyOwned = true;
                }
            }
            if (GameControl.control.denar >= (int)r.cena && !alreadyOwned)
            {
                WeaponManager.kupiOrozje(ind);
                trgovina.LoadItemsAvailable(trgovina.VrniArraySlik());
                GameManager.DodajDenar(-((int)r.cena));
            }
        }
    }

}
