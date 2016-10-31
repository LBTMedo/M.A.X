using UnityEngine;
using System.Collections;

public class Preveri : MonoBehaviour
{

    public bool PreveriGumb1;
    public bool PreveriGumb2;
    public bool PreveriGumb3;
    public GameObject target;
    private bool zaprto = true; //True -> zaprto
    private int ustavi = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool PGumb1, PGumb2, PGumb3;
        PGumb1 = Gumb.gumb1;
        PGumb2 = Gumb2.gumb2;
        PGumb3 = Gumb3.gumb3;

        if (PGumb1 == PreveriGumb1 && PGumb2 == PreveriGumb2 && PGumb3 && PreveriGumb3)
        {
            if (ustavi == 0)
            {

                target.transform.Translate(Vector3.forward * 10 );
                target.transform.Translate(Vector3.up *10 , Space.World);
                ustavi = 1;
            }
        }
        else
        {
            if (ustavi == 1)
            {


                target.transform.Translate(Vector3.forward * 10);
                target.transform.Translate(Vector3.down * 10, Space.World);
                ustavi = 0;

            }
        }

    }
}
