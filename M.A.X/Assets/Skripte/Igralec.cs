using UnityEngine;
using System.Collections;

[RequireComponent(typeof(IgralecKontroler))]
public class Igralec : MonoBehaviour {

    public float trenutnaZivljenja { get; set; }
    protected bool mrtev = false;

    public float zacetnaZivljenja;
    public event System.Action ObSmrti;

    void Start ()
    {
        trenutnaZivljenja = zacetnaZivljenja;
        Debug.Log(trenutnaZivljenja);
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            trenutnaZivljenja -= 1000;
            Debug.Log(trenutnaZivljenja);
        }

        if (trenutnaZivljenja <= 0 && !mrtev)
        {
            Smrt();
        }

    }

    public void PrejmiSkodo(float skoda)
    {
        trenutnaZivljenja -= skoda;
        Debug.Log(trenutnaZivljenja);
    }

    public void Smrt()
    {
        mrtev = true;
        Debug.Log("Smrt");
        if (ObSmrti != null)
        {
            ObSmrti();
        }
        Destroy(gameObject);
    }

}
