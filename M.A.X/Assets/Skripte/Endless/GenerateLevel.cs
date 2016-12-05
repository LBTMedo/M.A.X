using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GenerateLevel : MonoBehaviour {

    public GameObject[] prefabs;

    float[] maxXDelte = { 13f, 13f, 12f, 13f, 13f, 13f };
    float[] minXDelte = { 9f, 10f, 9f, 9f, 9f, 9f };

    float[] yScales = { 4f, 4f, 12f, 4f, 15f, 15f };

    float[] xPozicije = { 1f };

    [SerializeField]
    int trenutniPrefab;
    [SerializeField]
    int stevec;
    int menjaj = 20;

    EndlessPC kontroler;

    public float maxYDelta = 3f;

    Vector3 trenutnaPlatforma;

    public Text scoreText;
    public float score;

    public float speed;

    public GameObject coin;

    void Start()
    {
        trenutnaPlatforma = new Vector3(-6.8f, 0);
        trenutniPrefab = 0;
        stevec = 0;

        kontroler = FindObjectOfType<EndlessPC>();

        speed = kontroler.hitrostPremikanje;
    }

    void Update()
    {
        speed = kontroler.hitrostPremikanje;
        score += Time.deltaTime * speed;
        scoreText.text = Mathf.RoundToInt(score).ToString();
    }

    public void SpawnNext(Vector3 pozicija)
    {
        float scale = Random.Range(0.5f, 1.5f);

        stevec++;
        if (stevec == 5)
        {
            trenutniPrefab++;
            if (trenutniPrefab == prefabs.Length)
            {
                trenutniPrefab = 0;
            }
            stevec = 0;
        }
        Vector3 spawnPosition = new Vector3(pozicija.x + Random.Range(minXDelte[trenutniPrefab], maxXDelte[trenutniPrefab] - (1f/scale)), pozicija.y + Random.Range(-maxYDelta, maxYDelta - (1f/scale)));
        GameObject platforma = Instantiate(prefabs[trenutniPrefab], spawnPosition, Quaternion.identity) as GameObject;
        platforma.transform.localScale = new Vector3(platforma.transform.localScale.x * scale, yScales[trenutniPrefab]);
    }
}
