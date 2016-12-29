using UnityEngine;
using System.Collections;

public class CoopButton : MonoBehaviour {

    Vector3 defaultPos = new Vector3();
    Vector3 pushedPos;
    [SerializeField]
    LogObstacle obstacle;

    void Start()
    {
        defaultPos = transform.position;
        pushedPos = new Vector3(defaultPos.x, defaultPos.y - 0.20f, defaultPos.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.position = pushedPos;
            obstacle.SetState(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.position = defaultPos;
            obstacle.SetState(true);
        }
    }
}
