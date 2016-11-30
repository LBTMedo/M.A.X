using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    public GameObject minionMetek;

    public Transform spawn;
    Rigidbody2D metek;

    public float timer = 3f;

   [SerializeField]
    private float speed = 100f;

    private void Start()
    {
        SpawnMinion();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 3f;
            SpawnMinion();
        }
    }

    private void FixedUpdate()
    {

    }

    public void SpawnMinion()
    {
        metek = Instantiate(minionMetek, spawn.position, spawn.rotation) as Rigidbody2D;
    }
}
