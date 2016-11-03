using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AmmoSupply : MonoBehaviour {

    [SerializeField]
    private Text ammoValue;

	public float ChangeValue
    {
        set
        {
            //ammoValue = value + "/" + maxValue;
        }
    }
}
