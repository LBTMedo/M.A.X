using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public float speed = 1f;
    [SerializeField]
    int index;

    private void Start()
    {
        index = 0;
    }

    private void FixedUpdate()
    {
        Vector2 dir = Grid.nodesGO[index + 1].position - transform.position;
        transform.Translate(dir.normalized * speed * Time.fixedDeltaTime, Space.World);
        if(Vector2.Distance(transform.position, Grid.nodesGO[index+1].position) < 0.1f)
        {
            index++;
        }
    }
}
