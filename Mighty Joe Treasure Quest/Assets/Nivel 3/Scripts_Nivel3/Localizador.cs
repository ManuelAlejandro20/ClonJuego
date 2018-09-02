using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localizador : MonoBehaviour {

    public GameObject FlyingTroopers;
    static bool activoft;
    static bool activo2;

    AudioSource[] au;
    GameObject sonidos;
    public GameObject cofre;
    bool muertos;
    bool sonido = false;
    CofreHacha scriptcofre;
    AdminTesoros adm;
    GameObject admintesoros;
    void Awake () {
        sonidos = GameObject.Find("Sonidos");
        au = sonidos.GetComponents<AudioSource>();
        admintesoros = GameObject.Find("AdminTesoros");
        adm = admintesoros.GetComponent<AdminTesoros>();
        muertos = VidaFT.muerto;
        scriptcofre = cofre.GetComponent<CofreHacha>();
        if (muertos && adm.getnuminv() < 3) {
            cofre.transform.position = scriptcofre.getpossuelo();
            cofre.SetActive(true);
        }
	}

	
	void Update () {
        if (FlyingTroopers == null && !sonido ) {

            au[1].Play();
            sonido = true;

        }

        if (sonido) {
            gameObject.SetActive(false);
        }
	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !muertos)
        {
            FlyingTroopers.SetActive(true);
        }

    }

}
