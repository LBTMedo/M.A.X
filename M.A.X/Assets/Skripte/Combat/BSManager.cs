using UnityEngine;
using System.Collections;

public class BSManager : MonoBehaviour {

    private Igralec player;

    public Transform spawnPoint;

    public GameObject minion;

    public float timer = 3f;

	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<Igralec>();
        SpawnEnemy();
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = 3f;
            //SpawnEnemy();
        }
	}

    void SpawnEnemy()
    {
        Rigidbody2D enemy = Instantiate(minion, spawnPoint.position, spawnPoint.rotation) as Rigidbody2D;
    }
}
