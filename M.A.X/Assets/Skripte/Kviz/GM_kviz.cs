using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GM_kviz : MonoBehaviour {

    float preostaliCas = 20f;
    float countdown = 20f;
    public int steviloVprasanj = 5;
    int stevec = 0;
    int inkrement;

    [SerializeField]
    private int trenutnoVprasanje;

    public int denar;

    public GameObject[] gumbi;
    public Text[] textOdgovori;
    public Text vprasanje;

    public Text timeText;
    public Button gumb1;
    public Button gumb2;
    public Button gumb3;

   

    List<Vprasanje> izbranaVprasanja = new List<Vprasanje>();

    void Start()
    {
        //inkrement = SeznamVprasanj.vprasanja.Count / steviloVprasanj;

        for (int i = 0; i < steviloVprasanj; i++)
        {
            izbranaVprasanja.Add(SeznamVprasanj.vprasanja[Random.Range(0, SeznamVprasanj.vprasanja.Count - 1)]);
            //stevec += inkrement;
        }
        Debug.Log(izbranaVprasanja.Count.ToString());

        for (int i = 0; i < gumbi.Length; i++)
        {
            gumbi[i].SetActive(false);
        }

        NaslednjeVprasanje();
    }

    void Update()
    {
        if(countdown <= 0)
        {
           // NaslednjeVprasanje();
            countdown = preostaliCas;
        }

        countdown -= Time.deltaTime;
        timeText.text = Mathf.Floor(countdown + 1).ToString();
    }

    void NaslednjeVprasanje()
    {
        Vprasanje chosenQuestion = izbranaVprasanja[trenutnoVprasanje];
        int stOdgovorov = chosenQuestion.odgovori.Count;

        for (int i = 0; i < stOdgovorov; i++)
        {
            gumbi[i].SetActive(true);
            textOdgovori[i].text = chosenQuestion.odgovori[i].odgovor;
            Debug.Log(chosenQuestion.odgovori[i].odgovor);
        }

        vprasanje.text = chosenQuestion.vprasanje;

    }
}
