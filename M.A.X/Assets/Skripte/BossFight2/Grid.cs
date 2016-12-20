using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

    public static Transform[] nodesGO;
    public Vector2[] positions;

    public Transform end;
    public Transform start;

    private void Start()
    {
        nodesGO = new Transform[transform.childCount];
        positions = new Vector2[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            nodesGO[i] = transform.GetChild(i);
            positions[i] = new Vector2(nodesGO[i].transform.position.x + transform.position.x, nodesGO[i].transform.position.y + transform.position.y);
        }

        Debug.Log("Stevilo nodov: " + nodesGO.Length);

        Debug.Log("Razdalja: " + (Vector2.Distance(end.position, start.position)*10).ToString());
    }
}
