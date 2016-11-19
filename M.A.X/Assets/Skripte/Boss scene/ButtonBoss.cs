using UnityEngine;
using System.Collections;

public class ButtonBoss : MonoBehaviour
{

    RandomFlyingObjects objekti;
    
    [SerializeField]
    GameObject gumb;

    public Vector3 defaultButtonPos;
    Vector3 newButtonPos;

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
            objekti.GenerateAndDropObjects();
            gumb.transform.position = newButtonPos;
        }
    }

}
