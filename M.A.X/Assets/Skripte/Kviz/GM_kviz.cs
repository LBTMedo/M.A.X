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

    public int denar;

    public GameObject[] gumbi;

    public Text timeText;
    public Button gumb1;
    public Button gumb2;
    public Button gumb3;

    List<Vprasanje> izbranaVprasanja;

    void Start()
    {
        //gumb1.GetComponentInChildren<Text>().text = "Jaz sem gumb1";

        inkrement = SeznamVprasanj.vprasanja.Count / steviloVprasanj;

        izbranaVprasanja = new List<Vprasanje>();
        for (int i = 0; i < steviloVprasanj; i++)
        {
            izbranaVprasanja.Add(SeznamVprasanj.vprasanja[Random.Range(stevec, inkrement)]);
            stevec += inkrement;
        }

        gumbi[0].SetActive(false);
    }

    void Update()
    {
        if(countdown <= 0)
        {
            NaslednjeVprasanje();
            countdown = preostaliCas;
        }

        countdown -= Time.deltaTime;
        timeText.text = Mathf.Floor(countdown + 1).ToString();
    }

    void NaslednjeVprasanje()
    {
        Debug.Log("Naslednje vprasanje!");
    }
}
