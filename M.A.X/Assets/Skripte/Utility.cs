using UnityEngine;
using System.Collections;
using System;

public class Utility : MonoBehaviour {

    static void Swap<T>(ref T prvi, ref T drugi)
    {
        T zacasni;
        zacasni = prvi;
        prvi = drugi;
        drugi = zacasni;
    }

    public static void Uredi<T>(T[] polje, bool narascajoce) where T : IComparable
    {
        for(int i = 0; i < polje.Length; i++)
        {
            for(int j = 0; j < polje.Length - 1; j++)
            {
                if (narascajoce)
                {
                    if(polje[j].CompareTo(polje[j+1]) > 0)
                    {
                        Swap<T>(ref polje[j], ref polje[j + 1]);
                    }
                }
                else if (!narascajoce)
                {
                    if (polje[j].CompareTo(polje[j + 1]) < 0)
                    {
                        Swap<T>(ref polje[j], ref polje[j + 1]);
                    }
                }
            }
        }
    }
}
