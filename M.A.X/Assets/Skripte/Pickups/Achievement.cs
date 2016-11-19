using UnityEngine;
using System.Collections;

public class Achievement : MonoBehaviour {

    public int index;

    void OnTriggerEnter2D (Collider2D other)
    {
        Achievements.DodajAchievement(index);
        Destroy(gameObject);
    }
}
