using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour {

    public GameObject prefab;
    public float startTime;
    public float shootingCooldown;
    public bool playSound = false;
    public AudioClip spawnSound;
    AudioSource source;

    void Start()
    {
        InvokeRepeating("SpawnObject", startTime, shootingCooldown);
        if (playSound)
        {
            source = GetComponent<AudioSource>();
        }
    }

    void SpawnObject()
    {
        GameObject nov = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
        if (playSound)
        {
            source.PlayOneShot(spawnSound, GameControl.control.MASTER * GameControl.control.SFX);
        }
    }
}
