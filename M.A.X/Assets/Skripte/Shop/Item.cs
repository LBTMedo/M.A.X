using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    [SerializeField]
    private int indeks;

    BuyButton gumbKupi;

    void Start()
    {
        gumbKupi = FindObjectOfType<BuyButton>();
    }

    public void VrniIndeks()
    {
        gumbKupi.SetInd(indeks);
    }
}
