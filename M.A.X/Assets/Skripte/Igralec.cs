using UnityEngine;
using System.Collections;

[RequireComponent(typeof(IgralecKontroler))]
public class Igralec : MonoBehaviour {

    public float trenutnaZivljenja { get; set; }
    protected bool mrtev = false;

    public float zacetnaZivljenja;
    public event System.Action ObSmrti;

    [SerializeField]
    private IgralecStat health;

    void Start ()
    {
        trenutnaZivljenja = zacetnaZivljenja;
        Debug.Log(trenutnaZivljenja);
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            trenutnaZivljenja -= 100;
            health.CurrentVal -= 100;
            Debug.Log(trenutnaZivljenja);
        }

        if (trenutnaZivljenja <= 0 && !mrtev)
        {
            Smrt();
        }

       /* if (Input.GetKeyDown(KeyCode.Q))    
        {
            health.CurrentVal -= 10;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            health.CurrentVal += 100;
        }*/

    }

    private void Awake()
    {
        health.Initialize();
    }

    public void PrejmiSkodo(float skoda)
    {
        trenutnaZivljenja -= skoda;
        health.CurrentVal -= skoda;
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
