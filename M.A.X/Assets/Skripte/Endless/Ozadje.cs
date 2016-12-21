using UnityEngine;
using System.Collections;

public class Ozadje : MonoBehaviour {

    public Texture2D texture;
    Renderer renderer1;

    Igralec igralec;

    float speed;

    KameraEndless kamera;

    EndlessPC kontroler;

    float yPos;
    public float stevec = 5f;
    float orgStevec;

    private void Start()
    {
        renderer1 = GetComponent<Renderer>();
        renderer1.material.mainTexture = texture;

        igralec = FindObjectOfType<Igralec>();

        kamera = FindObjectOfType<KameraEndless>();

        yPos = igralec.transform.position.y;
        orgStevec = stevec;

        kontroler = FindObjectOfType<EndlessPC>();
        speed = 1 / kontroler.hitrostPremikanje;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(igralec.transform.position.x, yPos + 1.5f, transform.position.z), 1.5f);
        speed = 1 / kontroler.hitrostPremikanje;

        if (kamera.zacetek)
        {
            Vector2 offset = new Vector2(Time.time * speed, 0);
            renderer1.material.mainTextureOffset = offset;
        }

        stevec -= Time.deltaTime;
        if(stevec <= 0f)
        {
            stevec = orgStevec;
            yPos = Mathf.Lerp(yPos, igralec.transform.position.y - 10f, 0.01f);
        }
    }

}
