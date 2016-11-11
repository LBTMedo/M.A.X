using UnityEngine;
using System.Collections;

public class Igralec_borba : MonoBehaviour {

	public enum VrstaStreljanja { avtomatsko, enojno };

    public Transform tockaZaStreljanje;
    public Transform tarca;
    public Transform dnoIgralca;
    private Transform trenutnoOrozje;
    public float hitrostMetka = 5f;
    public float dmgObSkokuNaGlavo = 100f;

    public Transform zacetek;
    public Transform konec;

    public Rigidbody2D[] vrsteMetkov;
    [SerializeField]
    private int trenutniMetek;
    private IgralecKontroler kontroler;

    private VrstaStreljanja vrsta;

    public KeyCode streljanje;

    public bool desno;

    public bool avtomatsko;

    Coroutine avtomatskoStreljanje;

    void Start()
    {
        vrsta = VrstaStreljanja.enojno;
        trenutniMetek = 0;
        kontroler = GetComponent<IgralecKontroler>();
        desno = kontroler.desno;
        avtomatsko = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(streljanje))
        {
            if (vrsta == VrstaStreljanja.enojno)
            {
                Streljaj();
            }
            else
            {
                avtomatskoStreljanje = StartCoroutine(Streljanje());
            }
        }
        if (Input.GetKeyUp(streljanje))
        {
            if(vrsta == VrstaStreljanja.avtomatsko)
            {
                StopCoroutine(avtomatskoStreljanje);
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ZamenjajVrstoMetka();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponManager.ZamenjajOrozje();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            MeleeAttack();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(vrsta == VrstaStreljanja.enojno)
            {
                vrsta = VrstaStreljanja.avtomatsko;
            }
            else
            {
                vrsta = VrstaStreljanja.enojno;
            }
            avtomatsko = !avtomatsko;
        }
        Raycasting();
        desno = kontroler.desno;
        trenutnoOrozje = WeaponManager.VrniTrenutnoOrozje().parent;
    }

    void Streljaj()
    {
        Vector3 smer = (tarca.position - tockaZaStreljanje.position).normalized;

        Rigidbody2D instancaMetka = Instantiate(vrsteMetkov[trenutniMetek], tockaZaStreljanje.position, tockaZaStreljanje.rotation) as Rigidbody2D;
        if (desno)
        {
            instancaMetka.velocity = hitrostMetka * tockaZaStreljanje.right;
        }
        else
        {
            instancaMetka.velocity = hitrostMetka * (-tockaZaStreljanje.right);
        }
    }

    IEnumerator Streljanje()
    {
        for (;;)
        {
            Rigidbody2D instancaMetka = Instantiate(vrsteMetkov[trenutniMetek], tockaZaStreljanje.position, tockaZaStreljanje.rotation) as Rigidbody2D;
            if (desno)
            {
                instancaMetka.velocity = hitrostMetka * tockaZaStreljanje.right;
            }
            else
            {
                instancaMetka.velocity = hitrostMetka * (-tockaZaStreljanje.right);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    void MeleeAttack()
    {
        trenutnoOrozje.Rotate(new Vector3(0, 0, -60));
        trenutnoOrozje.position = new Vector3(trenutnoOrozje.position.x, trenutnoOrozje.position.y - 1f);
        Invoke("ZavrtiNazaj", 0.5f);
    }

    void ZavrtiNazaj()
    {
        trenutnoOrozje.Rotate(new Vector3(0, 0, 60));
        trenutnoOrozje.position = new Vector3(trenutnoOrozje.position.x, trenutnoOrozje.position.y + 1f);
    }

    void ZamenjajVrstoMetka()
    {
        int dolzina = vrsteMetkov.Length;
        trenutniMetek++;
        if(trenutniMetek == dolzina)
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
