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

    private float glasnost = 1f;
    public AudioClip zvok;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    public Transform zacetek;
    public Transform konec;

    public Rigidbody2D[] vrsteMetkov;
    public int trenutniMetek { private set; get; }
    private IgralecKontroler kontroler;

    Ammo ammo;

    bool seJeZeVrnilo = false;

    private VrstaStreljanja vrsta;

    public KeyCode streljanje;

    public bool desno;
    bool hasBullets;
    public bool avtomatsko;

    Coroutine avtomatskoStreljanje;

    int id = 0;

    void Start()
    {
        source = GetComponent<AudioSource>();
        vrsta = VrstaStreljanja.enojno;
        trenutniMetek = 0;
        kontroler = GetComponent<IgralecKontroler>();
        desno = kontroler.desno;
        avtomatsko = false;
        ammo = FindObjectOfType<Ammo>();
        hasBullets = true;
    }

    void Update()
    {
       // hasBullets = (ammo.metki[trenutniMetek] > 0) ? true : false;

        if (Input.GetKeyDown(streljanje) && hasBullets)
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
        if (Input.GetKeyUp(streljanje) || !hasBullets)
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
            if(WeaponManager.stOrozij() > 0)
            {
                WeaponManager.ZamenjajOrozje();
            }
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
        if (Input.GetKeyDown(KeyCode.B))
        {
            WeaponManager.kupiOrozje(id);
            id++;
        }

        Raycasting();
        desno = kontroler.desno;
        trenutnoOrozje = WeaponManager.VrniTrenutnoOrozje().parent;
    }

    void Streljaj()
    {
        source.volume = glasnost;
        source.PlayOneShot(zvok,glasnost);
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

        ammo.ZmanjsajSTMetkov(1, trenutniMetek);
    }

    IEnumerator Streljanje()
    {
        for (;;)
        {
            source.volume = 0.25f;
            source.PlayOneShot(zvok, 1F);
            Rigidbody2D instancaMetka = Instantiate(vrsteMetkov[trenutniMetek], tockaZaStreljanje.position, tockaZaStreljanje.rotation) as Rigidbody2D;
            if (desno)
            {
                instancaMetka.velocity = hitrostMetka * tockaZaStreljanje.right;
            }
            else
            {
                instancaMetka.velocity = hitrostMetka * (-tockaZaStreljanje.right);
            }

            ammo.ZmanjsajSTMetkov(1, trenutniMetek);

            yield return new WaitForSeconds(0.5f);
        }
    }

    void MeleeAttack()
    {
        if (WeaponManager.stOrozij() > 0)
        {
            trenutnoOrozje.Rotate(new Vector3(0, 0, -60));
            trenutnoOrozje.position = new Vector3(trenutnoOrozje.position.x, trenutnoOrozje.position.y - 1f);
            Invoke("ZavrtiNazaj", 0.5f);
        }
    }

    public void ZavrtiNazaj()
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
        ammo.ZamenjajIndex(trenutniMetek);
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
