using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    public float time = 3f;

    void Start()
    {
        Invoke("DestroyGO", time);
    }

    void DestroyGO()
    {
        Destroy(gameObject);
    }
	
	
}
