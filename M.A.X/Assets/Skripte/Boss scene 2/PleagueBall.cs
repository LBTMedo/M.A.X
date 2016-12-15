using UnityEngine;
using System.Collections;

public class PleagueBall : MonoBehaviour {

	void OnTriggerEnter2D()
    {
        Destroy(this.gameObject);
    }

}
