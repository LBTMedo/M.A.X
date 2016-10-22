using UnityEngine;
using System.Collections;

public class Subjekt : MonoBehaviour {

    public float zacetnaZivljenja;
    public float trenutnaZivljenja { get; protected set; }
    protected bool mrtev = false;

    public event System.Action ObSmrti;

	void Start () {
        trenutnaZivljenja = zacetnaZivljenja;
	}

    public void PrejmiSkodo(float skoda)
    {
        trenutnaZivljenja -= skoda;
        if(trenutnaZivljenja <= 0 && !mrtev)
        {
            Smrt();
        }
    }
	
	public virtual void Smrt()
    {
        mrtev = true;
        if(ObSmrti != null)
        {
            ObSmrti();
        }
        Destroy(gameObject);
    }
}
