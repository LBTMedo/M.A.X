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

    public bool disabled = false;

    bool seJeZeVrnilo = false;

    private VrstaStreljanja vrsta;

    public KeyCode streljanje;

    public bool desno;
    bool hasBullets;
    public bool avtomatsko;

    Coroutine avtomatskoStreljanje;

    private bool isStriking;

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
        isStriking = false;
    }

    void Update()
    {
        if (!disabled)
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
                if (vrsta == VrstaStreljanja.avtomatsko)
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
                if (WeaponManager.stOrozij() > 0)
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
                if (vrsta == VrstaStreljanja.enojno)
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
            //trenutnoOrozje = WeaponManager.VrniTrenutnoOrozje().parent;
            trenutnoOrozje = WeaponManager.VrniTrenutnoOrozje();
        }
    }

    public void Streljaj()
    {
        source.PlayOneShot(zvok, GameControl.control.MASTER * GameControl.control.SFX);
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
            source.PlayOneShot(zvok, GameControl.control.MASTER * GameControl.control.SFX);
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
            if (!isStriking)
            {
                float angle;
                isStriking = true;
                //trenutnoOrozje.Rotate(new Vector3(0, 0, -60));
                if (desno)
                    angle = 60f;
                else
                    angle = -60f;

                trenutnoOrozje.RotateAround(trenutnoOrozje.GetComponent<RocnoOrozje>().handPoint.position, Vector3.back, angle);
                //trenutnoOrozje.position = new Vector3(trenutnoOrozje.position.x, trenutnoOrozje.position.y - 1f);
                Invoke("ZavrtiNazaj", 0.2f);
            }           
        }
    }

    public void ZavrtiNazaj()
    {
        float angle;

        if (desno)
            angle = 60f;
        else
            angle = -60f;

        trenutnoOrozje.RotateAround(trenutnoOrozje.GetComponent<RocnoOrozje>().handPoint.position, Vector3.forward, angle);
        //trenutnoOrozje.Rotate(new Vector3(0, 0, 60));
        //trenutnoOrozje.position = new Vector3(trenutnoOrozje.position.x, trenutnoOrozje.position.y + 1f);
        isStriking = false;
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
