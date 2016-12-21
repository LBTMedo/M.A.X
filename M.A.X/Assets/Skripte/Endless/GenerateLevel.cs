using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GenerateLevel : MonoBehaviour {

    public GameObject[] prefabs;

    float maxXDelta = 52f;
    float minXDelta = 48f;

    float[] yScales = { 6f, 6f, 6f, 6f, 6f, 6f, 15f, 15f, 15f, 4.5f, 4.5f, 4.5f, 15f, 15f, 15f };

    float[] xPozicije = { 1f };

    [SerializeField]
    int trenutniPrefab;
    [SerializeField]
    int stevec;
    int menjaj = 20;

    int coins;

    EndlessPC kontroler;
    IgralecEndless igralec;

    public float maxYDelta = 1f;

    int multiplier;

    int currentMultiplier;

    Vector3 trenutnaPlatforma;

    public Text scoreText;
    public float score;

    public Text multiplierText;

    public Text endScore;
    public Text endDistance;
    public Text endCoins;

    public float distance;

    public GameObject endScreen;

    public float speed;

    public GameObject coin;

    float multiplierStevec;
    float orgMultiplierStevec;

    KameraEndless kamera;

    public Text PowerupWarning;
    public float powerupLimit = 500;
    float powerupAvailability;
    float powerupStevec;
    bool canUsePowerup = false;
    float powerupScore;

    void Start()
    {
        multiplier = 1;
        currentMultiplier = multiplier;

        multiplierText.text = currentMultiplier.ToString() + "X";

        trenutnaPlatforma = new Vector3(-6.8f, 0);
        trenutniPrefab = 0;
        stevec = 0;

        kontroler = FindObjectOfType<EndlessPC>();
        igralec = FindObjectOfType<IgralecEndless>();

        speed = kontroler.hitrostPremikanje;

        orgMultiplierStevec = 30f;
        multiplierStevec = orgMultiplierStevec;

        kamera = FindObjectOfType<KameraEndless>();

        coins = 0;

        powerupAvailability = 5f;
    }

    public void AddScore(float value)
    {
        score += value * currentMultiplier;
        powerupScore += value * currentMultiplier;
    }

    void Update()
    {
        if (kamera.zacetek)
        {
            speed = kontroler.hitrostPremikanje;
            score += Time.deltaTime * speed * currentMultiplier;
            powerupScore += Time.deltaTime * speed * currentMultiplier;
            scoreText.text = Mathf.RoundToInt(score).ToString();

            distance += (Time.deltaTime * speed) / 2;

            multiplierStevec -= Time.deltaTime;
            if (multiplierStevec <= 0f)
            {
                multiplier *= 2;
                currentMultiplier = multiplier;
                multiplierStevec = orgMultiplierStevec;
                multiplierText.text = currentMultiplier.ToString() + "X";
            }

            if(powerupScore >= powerupLimit)
            {
                PowerupWarning.gameObject.SetActive(true);
                powerupScore = 0;
                canUsePowerup = true;
                powerupLimit *= 4;
                StartCoroutine(DisableTekst());
            }

            if (Input.GetKeyDown(KeyCode.P) && canUsePowerup)
            {
                igralec.invincible = true;
                StartCoroutine(ResetInvincibility());
                canUsePowerup = false;
                PowerupWarning.gameObject.SetActive(false);
            }
        }

        //multiplierText.text = currentMultiplier.ToString() + "X";
    }

    IEnumerator ResetInvincibility()
    {
        yield return new WaitForSeconds(5f);
        igralec.invincible = false;
    }

    IEnumerator DisableTekst()
    {
        yield return new WaitForSeconds(powerupAvailability);
        PowerupWarning.gameObject.SetActive(false);
        canUsePowerup = false;
    }

    public void SpawnNext(Vector3 pozicija)
    {
        //float scale = Random.Range(0.5f, 1.5f);

        stevec++;
        if (stevec == 20)
        {
            trenutniPrefab += 3;
            if (trenutniPrefab == prefabs.Length)
            {
                trenutniPrefab = 0;
            }
            stevec = 0;
        }

        int odklon = Random.Range(0, 2);

        Vector3 spawnPosition = new Vector3(pozicija.x + Random.Range(minXDelta, maxXDelta), pozicija.y + Random.Range(-maxYDelta, maxYDelta));
        GameObject platforma = Instantiate(prefabs[trenutniPrefab+odklon], spawnPosition, Quaternion.identity) as GameObject;
        platforma.transform.localScale = new Vector3(platforma.transform.localScale.x, yScales[trenutniPrefab]);
    }

    public void ChangeMultiplier(int times)
    {
        currentMultiplier = currentMultiplier * times;
        multiplierText.text = currentMultiplier.ToString() + "X";
        StartCoroutine(ResetMultiplier(times));
    }

    IEnumerator ResetMultiplier(int times)
    {
        yield return new WaitForSeconds(10);

        currentMultiplier = currentMultiplier / times;
        multiplierText.text = currentMultiplier.ToString() + "X";
    }

    public void Konec()
    {
        endCoins.text = "Coins: " + coins.ToString();
        endScore.text = "Score: " + Mathf.RoundToInt(score).ToString();
        endDistance.text = "Distance: " + Mathf.RoundToInt(distance).ToString() + "m";

        endScreen.SetActive(true);
    }
}
