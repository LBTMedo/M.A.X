using UnityEngine;
using System.Collections;

public class BSManager : MonoBehaviour {

    private Igralec player;

    public Transform spawnPoint;

    public GameObject minion;

    public float timer = 3f;

	void Start ()
    {
        player = FindObjectOfType<Igralec>();
	}
	

    public void SpawnEnemy(Vector3 position, Quaternion rotation)
    {
        Rigidbody2D enemy = Instantiate(minion, spawnPoint.position, spawnPoint.rotation) as Rigidbody2D;
    }
}
