using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NivelSuperado : MonoBehaviour {

    GameObject admintesoros;
    AdminTesoros at;

	Canvas canvas;
	AudioSource au;

	bool sonido = true;

	VidaJoe scriptvida;
	GameObject jugador;

	GameObject gameobject_musica;
	AudioSource[] au_gameobject_musica;
    AudioSource au_gameobject_musica2;

    int escena_actual;

    void Awake() {

        escena_actual = SceneManager.GetActiveScene().buildIndex;
        if (escena_actual != 16)
        {
            admintesoros = GameObject.Find("AdminTesoros");
            gameobject_musica = GameObject.Find("Música");
            at = admintesoros.GetComponent<AdminTesoros>();
        }

		jugador = GameObject.FindGameObjectWithTag ("Player");
		scriptvida = jugador.GetComponent<VidaJoe> ();

		canvas = GetComponent<Canvas> ();
		au = GetComponent<AudioSource> ();

        if ((escena_actual != 16))
        {
            if (escena_actual == 3)
            {
                au_gameobject_musica = gameobject_musica.GetComponents<AudioSource>();
                au_gameobject_musica2 = null;

            }
            else
            {
                au_gameobject_musica2 = gameobject_musica.GetComponent<AudioSource>();
                au_gameobject_musica = null;

            }
        }
    }

	void Start () {
		
	}

	void Update () {

        if (canvas.enabled && sonido) {
            if (escena_actual != 16)
            {
                at.eliminartesoros();
                if (au_gameobject_musica2 == null)
                {

                    if (au_gameobject_musica[0].isPlaying)
                    {
                        au_gameobject_musica[0].Pause();
                    }
                    else if (au_gameobject_musica[1].isPlaying)
                    {
                        au_gameobject_musica[1].Pause();
                    }
                }
                else
                {

                    au_gameobject_musica2.Pause();

                }
            }
            scriptvida.setvida(100f);
            scriptvida.setvida1up(scriptvida.getvida1up() + 1);
            au.Play();
            
			sonido = false;
		}

	}
}
