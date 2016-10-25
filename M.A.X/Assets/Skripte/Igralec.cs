using UnityEngine;
using System.Collections;

[RequireComponent(typeof(IgralecKontroler))]
public class Igralec : Subjekt {

    public int[] poljeIntov;
    public string[] poljeStringov;

	void Start ()
    {
        poljeIntov = new int[10];
        poljeStringov = new string[5];

        for(int i = 0; i < poljeIntov.Length; i++)
        {
            poljeIntov[i] = Mathf.RoundToInt(Random.Range(1, 100));
        }

        for (int i = 0; i < poljeIntov.Length; i++)
        {
            Debug.Log(poljeIntov[i]);
        }

        Debug.Log("-----------------");

        Utility.Uredi(poljeIntov, false);

        for (int i = 0; i < poljeIntov.Length; i++)
        {
            Debug.Log(poljeIntov[i]);
        }
    }
	
	void Update ()
    {
	
	}

    public override void Smrt()
    {
        base.Smrt();
    }

}
