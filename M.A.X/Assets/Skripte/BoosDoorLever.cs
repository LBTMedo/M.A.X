using UnityEngine;
using System.Collections;

public class BoosDoorLever : MonoBehaviour {

    public bool pulled;
    public Sprite pulledSprite;
    private Sprite originalSprite;
    private SpriteRenderer Srenderer;
    public GameObject bdor;
	// Use this for initialization
	void Start () {
        pulled = false;
        Srenderer = GetComponent<SpriteRenderer>();
        originalSprite = Srenderer.sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F) && !pulled)
            {
                pulled = true;
                StartCoroutine(ChangeSprites());
                if (other.GetComponent<Artefacts>().full == true)
                {
                    bdor.GetComponent<BossDoor>().open = true;
                }
            }
        }
    }

    IEnumerator ChangeSprites()
    {
        Srenderer.sprite = pulledSprite;
        yield return new WaitForSeconds(2);
        Srenderer.sprite = originalSprite;
        pulled = false;
    }
}
