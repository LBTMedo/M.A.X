using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Achievements : MonoBehaviour {

    static bool[] achievementList;

    void Start()
    {
        achievementList = new bool[transform.childCount];
        for (int i = 0; i < achievementList.Length; i++)
        {
            achievementList[i] = false;
        }
    }

    public static void DodajAchievement(int index)
    {
        achievementList[index] = true;
        if (Polno())
        {
            Debug.Log("Vsi achievementi pobrani!");
        }
    }

    static bool Polno()
    {
        for (int i = 0; i < achievementList.Length; i++)
        {
            if(achievementList[i] == false)
            {
                return false;
            }
        }
        return true;
    }
}
