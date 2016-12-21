using UnityEngine;
using System.Collections;

public class JellyBounce : MonoBehaviour {

    public Sprite bounced;
    public Sprite unBounced;
    SpriteRenderer jellySprite;

    void Start()
    {
        jellySprite = GetComponent<SpriteRenderer>();
    }

    /*void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        jellySprite.sprite = bounced;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        jellySprite.sprite = unBounced;
    }*/

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            StartCoroutine(Bounce());
        }
    }

    IEnumerator Bounce()
    {
        jellySprite.sprite = bounced;
        yield return new WaitForSeconds(0.2f);
        jellySprite.sprite = unBounced;
    }

}
