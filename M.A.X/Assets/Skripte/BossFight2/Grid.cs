using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

    public static Transform[] nodesGO;
    public Node[] nodes;
    public Vector2[] positions;

    public static Grid instance;

    public Transform end;
    public Transform start;

    public static int currentIndex;
    public static int currentPlayerIndex;
    public static int childs;

    private void Awake()
    {
        childs = transform.childCount - 1;
    }

    private void Start()
    {
        instance = this;

        nodesGO = new Transform[transform.childCount - 1];
        nodes = new Node[transform.childCount - 1];
        positions = new Vector2[transform.childCount - 1];

        for (int i = 0; i < transform.childCount - 1; i++)
        {
            nodesGO[i] = transform.GetChild(i);
            positions[i] = new Vector2(nodesGO[i].position.x, nodesGO[i].position.y);
            nodes[i] = transform.GetChild(i).gameObject.GetComponent<Node>();
            nodes[i].index = i;
            nodes[i].x = i % 13;
            nodes[i].y = i / 13;
        }

        Debug.Log("Stevilo nodov: " + nodesGO.Length);

        Debug.Log("Razdalja: " + (Vector2.Distance(end.position, start.position)*10).ToString());
    }

    public Node returnNode(int indeks)
    {
        return nodes[indeks];
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        int nodeIndex = Utility.NodeIndexFromPosition(node.position);

        if ((nodeIndex + 1) < childs)
        {
            neighbours.Add(nodes[nodeIndex + 1]);
        }
        if ((nodeIndex - 1) < childs)
        {
            neighbours.Add(nodes[nodeIndex -1]);
        }
        if ((nodeIndex + 13) < childs)
        {
            neighbours.Add(nodes[nodeIndex + 13]);
        }
        if ((nodeIndex - 13) < childs)
        {
            neighbours.Add(nodes[nodeIndex - 13]);
        }
        if ((nodeIndex + 15) < childs)
        {
            neighbours.Add(nodes[nodeIndex + 14]);
        }
        if ((nodeIndex + 12) < childs)
        {
            neighbours.Add(nodes[nodeIndex + 12]);
        }
        if ((nodeIndex - 14) < childs)
        {
            neighbours.Add(nodes[nodeIndex - 14]);
        }
        if ((nodeIndex - 12) < childs)
        {
            neighbours.Add(nodes[nodeIndex - 12]);
        }

        /*for (int i = 0; i < neighbours.Count; i++)
        {
            Debug.Log(nodes[neighbours[i].index].ToString());
        }*/

        return neighbours;
    }


}
