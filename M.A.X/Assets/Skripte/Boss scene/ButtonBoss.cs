using UnityEngine;
using System.Collections;

public class ButtonBoss : MonoBehaviour
{

    RandomFlyingObjects objekti;
    
    [SerializeField]
    GameObject gumb;

    public Vector3 defaultButtonPos;
    Vector3 newButtonPos;

    [SerializeField]
    GameObject cameraToShake;

    void Start()
    {
        objekti = FindObjectOfType<RandomFlyingObjects>();
        defaultButtonPos = gumb.transform.position;
        newButtonPos = new Vector3(defaultButtonPos.x, defaultButtonPos.y - 0.20f, defaultButtonPos.z);
        
    }

    void OnCollisionEnter2D()
    {
        if (objekti.Reloaded())
        {
            cameraToShake.GetComponent<CameraShake>().ShakeCamera(10f, 0.05f);
            objekti.GenerateAndDropObjects();
            gumb.transform.position = newButtonPos;
        }
    }

}
