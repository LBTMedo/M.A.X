using UnityEngine;
using System.Collections;

public class BuyButton : MonoBehaviour {

   
    private int ind = -1;

    public void SetInd(int n)
    {
        ind = n;
    }

    public void Kupi()
    {
        if (ind != -1)
        {
            WeaponManager.kupiOrozje(ind);
        }
    }

}
