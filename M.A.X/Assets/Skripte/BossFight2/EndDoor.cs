using UnityEngine;
using System.Collections;

public class EndDoor : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.RestartGame();
        }
    }
}
