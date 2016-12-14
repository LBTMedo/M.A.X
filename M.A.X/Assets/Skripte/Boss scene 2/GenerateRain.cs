using UnityEngine;
using System.Collections;

public class GenerateRain : MonoBehaviour {

    public GameObject prefab;
    public int numOfRepetitions;
    public int numOfDrops;
    public float heightOfGeneration;
    public float minX;
    public float maxX;

    bool reloading = false;

    void Update()
    {
        if (!reloading)
        {
            StartCoroutine(Reload());
        }
    }

    public void GenerateRainDrops()
    {
        //int changeNumOfDrops = numOfRepetitions / 2;
        //for (int j = 0; j < numOfRepetitions; j++)
        //{
            for (int i = 0; i < numOfDrops; i++)
            {
                float posX = Random.Range(minX, maxX);
                Vector3 pozicija = new Vector3(posX, heightOfGeneration, 0);
                Instantiate(prefab, pozicija, Quaternion.identity);
            }
           /* if(numOfRepetitions < changeNumOfDrops)
            {
                numOfDrops *= (int)1.5;
            }
            else
            {
                numOfDrops /= (int)1.5;
            }*/
       // }
    }

    IEnumerator Reload()
    {
        int restoreNumOfDrops = numOfDrops;
        int changeNumOfDrops = numOfRepetitions / 2;
        for (int i = 0; i < numOfRepetitions; i++)
        {
            GenerateRainDrops();
            if (numOfRepetitions < changeNumOfDrops)
            {
                numOfDrops *= (int)1.2;
            }
            else
            {
                numOfDrops = numOfDrops/(int)1.2;
            }
            yield return new WaitForSeconds(1);
        }
        numOfDrops = restoreNumOfDrops;
        reloading = true;
        yield return new WaitForSeconds(5);
        reloading = false;
    }
}
