using UnityEngine;
using System.Collections;

public class GenerateRain : MonoBehaviour {

    public GameObject prefab;
    public int numOfRepetitions;
    public int numOfDrops;
    public float heightOfGeneration;
    public float minX;
    public float maxX;
    public float coolDown;
    bool reloading = false;
    bool firstTime = true;

    void Update()
    {
        if (!reloading)
        {
            StartCoroutine(Reload());
        }
    }

    public void GenerateRainDrops()
    {
            for (int i = 0; i < numOfDrops; i++)
            {
                float posX = Random.Range(minX, maxX);
                Vector3 pozicija = new Vector3(posX, heightOfGeneration, 0);
                Instantiate(prefab, pozicija, Quaternion.identity);
            }
    }

    IEnumerator Reload()
    {
        reloading = true;
        if (firstTime)
        {
            yield return new WaitForSeconds(coolDown);
            firstTime = false;
        }
        int restoreNumOfDrops = numOfDrops;
        int changeNumOfDrops = numOfRepetitions / 2;
        for (int i = 0; i < numOfRepetitions; i++)
        {
            GenerateRainDrops();
            if (numOfRepetitions < changeNumOfDrops)
            {
                numOfDrops += numOfDrops*2;
            }
            else
            {
                numOfDrops -= numOfDrops*2;
            }
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(coolDown);
        numOfDrops = restoreNumOfDrops;
        reloading = false;
    }
}
