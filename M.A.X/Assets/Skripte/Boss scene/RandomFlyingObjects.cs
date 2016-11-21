using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomFlyingObjects : MonoBehaviour {

    [SerializeField]
    GameObject parent;
    Transform[] children;
    bool reloaded;

    public GameObject[] prefab;

    [SerializeField]
    GameObject gumb;
    ButtonBoss gumb1;

	void Start()
    {
        reloaded = true;
        children = parent.GetComponentsInChildren<Transform>();
        gumb1 = FindObjectOfType<ButtonBoss>();
    }

    public bool Reloaded()
    {
        return reloaded;
    }

    public void GenerateAndDropObjects()
    {
        int[] chosenIndex;

        int numOfObjects = Random.Range(2, 4);

        chosenIndex = new int[numOfObjects];

        for (int i = 0; i < numOfObjects; i++)
        {
            int theChosenOne = Random.Range(0, children.Length - 1);
            foreach (int i1 in chosenIndex)
            {
                if (i1 == theChosenOne)
                {
                    while (i1 == theChosenOne)
                    {
                        theChosenOne = Random.Range(0, children.Length - 1);
                    }
                }
            }
            chosenIndex[i] = theChosenOne;
        }

        foreach(int i2 in chosenIndex)
        {
            int prefabNum = Random.Range(1, prefab.Length);
            Instantiate(prefab[prefabNum], children[i2].position, children[i2].rotation);
        }

        reloaded = false;
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(5);
        reloaded = true;
        gumb.transform.position = gumb1.defaultButtonPos;
    }
}
