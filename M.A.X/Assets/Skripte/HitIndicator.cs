using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HitIndicator : MonoBehaviour
{

    public float flashSpeed = 10.0f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.7f);
    public Image flashImage;
    public Color defaultColor = new Color(1f, 0f, 0f, 0f);

    public bool sceneLoad = true;
    public bool damaged;

    // Use this for initialization
    void Start()
    {
        flashImage.color = defaultColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneLoad != true)
        {
            if (damaged)
            {
                flashImage.color = flashColor;
            }
            else
            {
                flashImage.color = Color.Lerp(flashImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }
            damaged = false;
        }
    }

}
