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

    public int pooledAmount = 10;
    List<GameObject> objects;

    void Start()
    {
        objects = new List<GameObject>();
        for (int i= 0; i<pooledAmount; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            objects.Add(obj);
        }
        InvokeRepeating("SpawnObject", startTime, shootingCooldown);
        if (playSound)
        {
            source = GetComponent<AudioSource>();
        }
    }

    void SpawnObject()
    {
        /*GameObject nov = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
        if (playSound)
        {
            source.PlayOneShot(spawnSound, GameControl.control.MASTER * GameControl.control.SFX);
        }*/
        for(int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].activeInHierarchy)
            {
                objects[i].transform.position = transform.position;
                objects[i].transform.rotation = transform.rotation;
                objects[i].SetActive(true);
                if (playSound)
                {
                    source.PlayOneShot(spawnSound, GameControl.control.MASTER * GameControl.control.SFX);
                }
                break;
            }
        }
    }
}
