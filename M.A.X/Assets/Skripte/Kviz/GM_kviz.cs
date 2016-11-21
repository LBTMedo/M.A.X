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

    public int pravilniOdgovori = 0;
    public bool konecIgre = false;

    public int denar;

    public GameObject[] gumbi;
    public GameObject kartica;
    public GameObject casTekst;
    public GameObject konecTekst;
    public Text[] textOdgovori;
    public Text vprasanje;

    Vprasanje chosenQuestion;

    public Text timeText;
    public Text endText;
    public Button gumb1;
    public Button gumb2;
    public Button gumb3;

    List<Vprasanje> izbranaVprasanja = new List<Vprasanje>();

    void Start()
    {
        trenutnoVprasanje = 0;

        for (int i = 0; i < steviloVprasanj; i++)
        {
            int index = Random.Range(0, SeznamVprasanj.vprasanja.Count - 1);
            izbranaVprasanja.Add(SeznamVprasanj.vprasanja[index]);
            SeznamVprasanj.vprasanja.RemoveAt(index);
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
        if (!konecIgre)
        {
            if (countdown <= 0)
            {
                NaslednjeVprasanje();
                countdown = preostaliCas;
            }

            countdown -= Time.deltaTime;
            timeText.text = Mathf.Floor(countdown + 1).ToString();
        }
    }

    void NaslednjeVprasanje()
    {
        countdown = preostaliCas;

        if (trenutnoVprasanje == steviloVprasanj)
        {
            konecIgre = true;
            for (int i = 0; i < gumbi.Length; i++)
            {
                gumbi[i].SetActive(false);
            }

            kartica.SetActive(false);
            casTekst.SetActive(false);
            endText.text = "Konec igre\n " + pravilniOdgovori + " / " + steviloVprasanj;
            konecTekst.SetActive(true);
        }

        chosenQuestion = izbranaVprasanja[trenutnoVprasanje];
        int stOdgovorov = chosenQuestion.odgovori.Count;

        for (int i = 0; i < chosenQuestion.odgovori.Count; i++)
        {
            gumbi[i].GetComponent<Image>().color = Color.white;
        }

        for (int i = 0; i < gumbi.Length; i++)
        {
            gumbi[i].SetActive(false);
        }

        for (int i = 0; i < stOdgovorov; i++)
        {
            gumbi[i].SetActive(true);
            textOdgovori[i].text = chosenQuestion.odgovori[i].odgovor;
            Debug.Log(chosenQuestion.odgovori[i].odgovor);
        }

        vprasanje.text = chosenQuestion.vprasanje;

        
        trenutnoVprasanje++;
    }

    public void Gumb1()
    {
        if (chosenQuestion.odgovori[0].pravilnost)
        {
            gumbi[0].GetComponent<Image>().color = Color.green;
            pravilniOdgovori++;
        }
        else
        {
            gumbi[0].GetComponent<Image>().color = Color.red;
            for (int i = 0; i < chosenQuestion.odgovori.Count; i++)
            {
                if (chosenQuestion.odgovori[i].pravilnost)
                {
                    gumbi[i].GetComponent<Image>().color = Color.green;
                }
            }
        }

        if (preostaliCas >= 2f)
        {
            Invoke("NaslednjeVprasanje", 1f);
        }
    }

    public void Gumb2()
    {
        if (chosenQuestion.odgovori[1].pravilnost)
        {
            gumbi[1].GetComponent<Image>().color = Color.green;
            pravilniOdgovori++;
        }
        else
        {
            gumbi[1].GetComponent<Image>().color = Color.red;
            for (int i = 0; i < chosenQuestion.odgovori.Count; i++)
            {
                if (chosenQuestion.odgovori[i].pravilnost)
                {
                    gumbi[i].GetComponent<Image>().color = Color.green;
                }
            }
        }

        if(preostaliCas >= 2f)
        {
            Invoke("NaslednjeVprasanje", 1f);
        }
    }

    public void Gumb3()
    {
        if (chosenQuestion.odgovori[2].pravilnost)
        {
            gumbi[2].GetComponent<Image>().color = Color.green;
            pravilniOdgovori++;
        }
        else
        {
            gumbi[2].GetComponent<Image>().color = Color.red;
            for (int i = 0; i < chosenQuestion.odgovori.Count; i++)
            {
                if (chosenQuestion.odgovori[i].pravilnost)
                {
                    gumbi[i].GetComponent<Image>().color = Color.green;
                }
            }
        }

        if (preostaliCas >= 2f)
        {
            Invoke("NaslednjeVprasanje", 1f);
        }
    }
}
