using UnityEngine;
using System.Collections;

public class EnemyAI2 : MonoBehaviour {

    Igralec igralec;

    [SerializeField]
    private float damagePerSecond = 5f;
    [SerializeField]
    private float damageRadius = 5f;

    [SerializeField]
    private bool playerDetected;

    public LayerMask igralecMask;

    void Awake()
    {
        igralec = FindObjectOfType<Igralec>();
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
                yield return new WaitForSeconds(damagePerSecond);
            }
        }
    }

     
}
