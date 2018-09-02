using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MúsicaNivel2 : MonoBehaviour {

    public AudioClip[] audios;
    VidaJoe vida;
    GameObject jugador;
    AudioSource[] aus;
    bool loop = false;

    public int escena;
    void Awake()
    {

        escena = SceneManager.GetActiveScene().buildIndex;
        if (escena <= 7 && escena >= 4)
        {
            jugador = GameObject.FindGameObjectWithTag("Player");
            vida = jugador.GetComponent<VidaJoe>();
            aus = GetComponents<AudioSource>();
            DontDestroyOnLoad(gameObject);
            if (FindObjectsOfType(GetType()).Length > 1)
            {
                Destroy(gameObject);
            }
        }

    }

    void Start()
    {
    }


    void Update()
    {

        escena = SceneManager.GetActiveScene().buildIndex;
        if (escena > 7)
        {
            Destroy(gameObject);
        }


    }

    void FixedUpdate()
    {

        if (!loop)
        {

            aus[1].PlayDelayed(audios[0].length + 0.0008f);
            loop = true;
        }

        if (vida.getvida() <= 0)
        {
            Destroy(gameObject);

        }




    }
}
