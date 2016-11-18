﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomFlyingObjects : MonoBehaviour {

    [SerializeField]
    GameObject parent;
    Transform[] children;

    public GameObject prefab;

	void Start()
    {
        children = parent.GetComponentsInChildren<Transform>();
    }

    void GenerateAndDropObjects()
    {
        int[] chosenIndex;
        chosenIndex = new int[3];

        int numOfObjects = Random.Range(2, 4);

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
            Instantiate(prefab, children[i2].position, children[i2].rotation);
        }
    }
}
