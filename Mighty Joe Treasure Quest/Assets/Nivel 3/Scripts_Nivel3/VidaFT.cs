using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaFT : MonoBehaviour
{

    public float vida;
    public GameObject suelobarco;
    VidaJoe scriptvida;
    GameObject jugador;
    Animator animator;
    public GameObject explosiones;
    public GameObject cofre;

    float tiempo;
    bool muerte = false;
    bool sonidomuerte = false;
    public static bool muerto = false;

    AudioSource[] au;

    AdminTesoros adm;
    GameObject admintesoros;

    void Awake()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        admintesoros = GameObject.Find("AdminTesoros");
        adm = admintesoros.GetComponent<AdminTesoros>();
        scriptvida = jugador.GetComponent<VidaJoe>();
        animator = GetComponent<Animator>();
        au = GetComponents<AudioSource>();

    }


    void Update()
    {

        if (muerte)
        {
            if (!sonidomuerte)
            {
                au[2].Play();
                sonidomuerte = true;
            }
            animator.speed = 2;
            explosiones.SetActive(true);
            tiempo += Time.deltaTime;
            if (tiempo >= 4f)
            {
                if (adm.getnuminv() < 3)
                {
                    cofre.transform.position = transform.position;
                    cofre.SetActive(true);
                }
                Destroy(gameObject);
            }

        }


    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            scriptvida.setvida(scriptvida.getvida() - 10f);
            au[3].Play();
        }

    }


    public void OnTriggerEnter2D(Collider2D colo)
    {

        if (colo.tag == "Bullet")
        {
            au[3].Play();
            jugador = GameObject.FindGameObjectWithTag("Player");
            ProyectilComportamiento proycomp = jugador.GetComponent<ProyectilComportamiento>();

            colo.transform.position = new Vector3(-1000, -1000, -6f);
            proycomp.agregar(colo.gameObject);
            Proyectil proyectil = colo.gameObject.GetComponent<Proyectil>();
            vida -= proyectil.getdaño();


            if (vida <= 0)
            {
                muerte = true;
                muerto = muerte;

            }

        }

        if (colo.tag == "Uppercut") {
            GameObject sonidos = GameObject.Find("Sonidos");
            AudioSource[] au = sonidos.GetComponents<AudioSource>();
            au[2].Play();
            vida -= 100f;
            if (vida <= 0)
            {
                muerte = true;
                muerto = muerte;

            }
        }

        if (colo.name == "ExplosionBomba")
        {

            au[4].Play();
            vida -= 50f;

        }

    }



}
