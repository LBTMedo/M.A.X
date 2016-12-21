using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour , IHeapItem<Node> {

    public Vector2 position;

    public Vector2 actPos;

    public bool walkable = true;

    public int index;
    public int x;
    public int y;

    public int hCost;
    public int gCost;
    public int fcost;

    public Node parent;

    private void Start()
    {
        position = new Vector2(transform.position.x - transform.parent.position.x, transform.position.y - transform.parent.position.y);
        actPos = new Vector2(position.x + transform.parent.position.x, position.y + transform.parent.position.y);
    }

    public void CalculateCosts(Vector3 startNode, Vector3 endNode)
    {
        hCost = Mathf.RoundToInt(Vector2.Distance(position, endNode)) * 10;
        gCost = Mathf.RoundToInt(Vector2.Distance(position, startNode)) * 10;

        fcost = hCost + gCost;
    }

    public int heapIndex
    {
        get
        {
            return fcost;
        }
        set
        {
            fcost = value;
        }
    }

    public int CompareTo(Node nodeToCompare)
    {
        int compare = fcost.CompareTo(nodeToCompare.fcost);
        if(compare == 0)
        {
            compare = hCost.CompareTo(nodeToCompare.hCost);
        }
        return -compare;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Sovraznik")
        {
            Grid.currentIndex = index;
        }
        if (collision.gameObject.tag == "Igralec")
        {
            Grid.currentPlayerIndex = index;
        }
    }
}
