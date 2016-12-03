using UnityEngine;
using System.Collections;

public class GenerateLevel : MonoBehaviour {

    public GameObject[] prefabs;

    float[] maxXDelte = { 13f, 13f, 12f, 13f, 8f, 7f };
    float[] minXDelte = { 7.5f, 10f, 8f, 8f, 4.6f, 3.5f };

    [SerializeField]
    int trenutniPrefab;
    [SerializeField]
    int stevec;
    int menjaj = 20;

    public float maxYDelta = 1.6f;

    Vector3 trenutnaPlatforma;

    void Start()
    {
        trenutnaPlatforma = new Vector3(-6.8f, 0);
        trenutniPrefab = 0;
        stevec = 0;
    }

    void Update()
    {
        
    }

    public void SpawnNext(Vector3 pozicija)
    {
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
        Vector3 spawnPosition = new Vector3(pozicija.x + Random.Range(minXDelte[trenutniPrefab], maxXDelte[trenutniPrefab]), pozicija.y + Random.Range(-maxYDelta, maxYDelta));
        Instantiate(prefabs[trenutniPrefab], spawnPosition, Quaternion.identity);
    }
}
