using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tile : MonoBehaviour {

    public static bool DO_NOT = false;

    [SerializeField]
    private int state;

    [SerializeField]
    private int tileValue;

    [SerializeField]
    private bool initialized;

    private Sprite tileBack;
    private Sprite tileFace;

    private GameObject manager;

    void Start()
    {
        state = 1;
        manager = GameObject.FindGameObjectWithTag ("Manager");

    }

    public void setupGraphics()
    {
        tileBack = manager.GetComponent<GameManagerMiniGame>().GetTileBack();
        tileFace = manager.GetComponent<GameManagerMiniGame>().GetTileFace(tileValue);

        flipTile();
    }


    public void flipTile()
    {
        if (state == 0)
        {
            state = 1;
        }
        else if (state == 1)
        {
            state = 0;
        }

        if (state == 0 && !DO_NOT)
        {
            GetComponent<Image>().sprite = tileBack;
        }
        else if (state == 1 && !DO_NOT)
        {
            GetComponent<Image>().sprite = tileFace;
        }
    }

    public int TileValue
    {
            get { return tileValue; }
            set { tileValue = value; }
    }

    public int State
    {
        get { return state; }
        set { state = value; }
    }

    public bool Initialized
    {
        get { return initialized; }
        set { initialized = value; }
    }

    public void FalseCheck()
    {
        StartCoroutine(pause());
    }

    IEnumerator pause()
    {
        yield return new WaitForSeconds(1);
        if(state == 0)
        {
            GetComponent<Image>().sprite = tileBack;
        }
        else if (state == 1)
        {
            GetComponent<Image>().sprite = tileFace;
        }
        DO_NOT = false;
    }
}
