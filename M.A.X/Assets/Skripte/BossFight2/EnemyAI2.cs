using UnityEngine;
using System.Collections;

public class EnemyAI2 : MonoBehaviour {

    Igralec igralec;
    EnemyMovement movement;

    [SerializeField]
    private float damagePerSecond = 5f;
    [SerializeField]
    private float damageRadius = 5f;
    [SerializeField]
    private float health = 100f;

    [SerializeField]
    private bool playerDetected;

    public LayerMask igralecMask;

    public GameObject endDoor;

    void Awake()
    {
        igralec = FindObjectOfType<Igralec>();
        movement = GetComponent<EnemyMovement>();
    }

    void Start()
    {
        playerDetected = false;
        StartCoroutine(DealDamage());
    }

    void Update()
    {
        if(Physics2D.OverlapCircle(transform.position, damageRadius, igralecMask))
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }
    }

    IEnumerator DealDamage()
    {
        while (true)
        {
            if (playerDetected)
            {
                igralec.PrejmiSkodo(damagePerSecond);
            }
            yield return new WaitForSeconds(1);
        }
    }

    void PrejmiSkodo(float _damage)
    {
        health -= _damage;
        if(health <= 0f)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        movement.dead = true;
        yield return new WaitForSeconds(1);

        //Animacija smrti

        endDoor.SetActive(true);
        Destroy(gameObject);
    }
}
