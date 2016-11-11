using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public Sprite[] tileFace;
    public Sprite tileBack;
    public GameObject[] tiles;
    public Text matchText;

    public bool init = false;
    public int matches = 8;

	// Update is called once per frame
	void Update () {
        if (!init)
        {
            InitializeTiles();
        }
        if (Input.GetMouseButtonUp(0))
        {
            CheckTiles();
        }
	}

    void InitializeTiles()
    {
        for(int i = 0; i<2; i++)
        {
            for (int j = 1; j < 9; j++)
            {
                bool test = false;
                int choice = 0;
                while (!test)
                {
                    choice = Random.Range(0, tiles.Length);
                    test = !(tiles[choice].GetComponent<Tile>().Initialized);
                }
                tiles[choice].GetComponent<Tile>().TileValue = j;
                tiles[choice].GetComponent<Tile>().Initialized = true;
            }
        }
        foreach(GameObject t in tiles)
        {
            t.GetComponent<Tile>().setupGraphics();
        }
        if (!init)
        {
            init = true;
        }
    }

    public Sprite GetTileBack()
    {
        return tileBack;
    }

    public Sprite GetTileFace(int i)
    {
        return tileFace[i - 1];
    }

    void CheckTiles()
    {
        List<int> t = new List<int>();
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i].GetComponent<Tile>().State == 1)
            {
                t.Add(i);
            }
        }

        if (t.Count == 2)
        {
            TileComparison(t);
        }
    }

    void TileComparison(List<int> l)
    {
        Tile.DO_NOT = true;
        int x = 0;
        if(tiles[l[0]].GetComponent<Tile>().TileValue == tiles[l[1]].GetComponent<Tile>().TileValue)
        {
            x = 2;
            matches--;
            matchText.text = "Preostali pari: " + matches;
        }

        for ( int i=0; i < l.Count; i++)
        {
            tiles[l[i]].GetComponent<Tile>().State = x;
            tiles[l[i]].GetComponent<Tile>().FalseCheck();
        }
    }
}
