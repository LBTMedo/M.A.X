using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public float speed = 1f;
    [SerializeField]
    int index;

    public Vector2[] path;

    private void Start()
    {
        index = 0;
    }

    public void UpdatePath(Vector2[] _path)
    {
        path = _path;
        index = 0;
    }

    private void FixedUpdate()
    {
        Vector2 dir = path[index + 1] - (Vector2)transform.position;
        transform.Translate(dir.normalized * speed * Time.fixedDeltaTime, Space.World);
        if(Vector2.Distance(transform.position, path[index+1]) < 0.1f)
        {
            index++;
        }
    }
}
