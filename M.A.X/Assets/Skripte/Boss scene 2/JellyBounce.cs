using UnityEngine;
using System.Collections;

public class JellyBounce : MonoBehaviour {

    public Sprite bounced;
    public Sprite unBounced;

    GameObject jelly;
    SpriteRenderer jellySprite;

    void Start()
    {
        jelly = GetComponent<GameObject>();
        jellySprite = jelly.GetComponent<SpriteRenderer>();
    }

    /*void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            StartCoroutine(Sleep());
        }
    }*/

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        jellySprite.sprite = bounced;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        jellySprite.sprite = unBounced;
    }

	IEnumerator Sleep()
    {
        jellySprite.sprite = bounced;
        yield return new WaitForSeconds(0.5f);
        jellySprite.sprite = unBounced;
    }
}
