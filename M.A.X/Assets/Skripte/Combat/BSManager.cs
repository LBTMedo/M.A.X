using UnityEngine;
using System.Collections;

public class BSManager : MonoBehaviour {

    private Igralec player;

    public Transform spawnPoint;
    public Transform levo;
    public Transform desno;

    public GameObject minion;
    public GameObject healthPickup;
    public GameObject ammoPickup;

    public float timer = 3f;

	void Start ()
    {
        player = FindObjectOfType<Igralec>();
	}

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnPickup();
            timer = 3f;
        }
    }

    void SpawnPickup()
    {
        float num = Random.Range(0, 100);
        float xPos = Random.Range(levo.position.x, desno.position.x);
        if(num >= 50)
        {
            Instantiate(healthPickup, new Vector3(xPos, levo.position.y), Quaternion.identity);
        }
        else
        {
            Instantiate(ammoPickup, new Vector3(xPos, levo.position.y), Quaternion.identity);
        }
    }
	

    public void SpawnEnemy(Vector3 position, Quaternion rotation)
    {
        Rigidbody2D enemy = Instantiate(minion, spawnPoint.position, spawnPoint.rotation) as Rigidbody2D;
    }




}
