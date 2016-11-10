using UnityEngine;
using System.Collections;

public class Igralec_borba : MonoBehaviour {

	public enum VrstaStreljanja { avtomatsko, enojno };

    public Transform tockaZaStreljanje;
    public Transform dnoIgralca;
    public float hitrostMetka = 5f;
    public float dmgObSkokuNaGlavo = 100f;

    public Rigidbody2D[] vrsteMetkov;
    [SerializeField]
    private int trenutniMetek;

    private VrstaStreljanja vrsta;

    public KeyCode streljanje;

    void Start()
    {
        vrsta = VrstaStreljanja.enojno;
        trenutniMetek = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(streljanje))
        {
            Streljaj();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ZamenjajVrstoMetka();
        }
        Raycasting();
    }

    void Streljaj()
    {
        if(vrsta == VrstaStreljanja.enojno)
        {
            Rigidbody2D instancaMetka = Instantiate(vrsteMetkov[trenutniMetek], tockaZaStreljanje.position, tockaZaStreljanje.rotation) as Rigidbody2D;
            instancaMetka.velocity = hitrostMetka * tockaZaStreljanje.right;
        }
        else if(vrsta == VrstaStreljanja.avtomatsko)
        {

        }
    }

    void ZamenjajVrstoMetka()
    {
        int dolzina = vrsteMetkov.Length;
        trenutniMetek++;
        if(trenutniMetek > dolzina)
        {
            trenutniMetek = 0;
        }
    }

    void Raycasting()
    {
        Debug.DrawLine(dnoIgralca.position, new Vector3(dnoIgralca.position.x, dnoIgralca.position.y - 0.5f), Color.red);
        RaycastHit2D hit = Physics2D.Raycast(dnoIgralca.position, Vector2.down, 0.5f, 1 << LayerMask.NameToLayer("Sovraznik"));
        if(hit.collider != null)
        {
            hit.collider.gameObject.SendMessage("PrejmiSkodo", dmgObSkokuNaGlavo);
        }
    }
}
