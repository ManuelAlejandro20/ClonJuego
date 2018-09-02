using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    /*Todos los enemigos empiezan con la misma vida */
    public float vidaenemigo = 100f;
	public AudioClip[] efectos;
	AudioSource au;

    GameObject jugador;
    ProyectilComportamiento scriptcomportamiento;


    void Awake(){

        jugador = GameObject.FindGameObjectWithTag("Player");
        scriptcomportamiento = jugador.GetComponent<ProyectilComportamiento>();

        au = GetComponent<AudioSource> ();
	
	}

    void Update()
    {


    }



    /*Se detecta cuando el enemigo recibe un golpe o el Uppercut*/
    public void OnTriggerEnter2D(Collider2D col) {

        if (col.tag == "Bullet" || col.tag == "Uppercut") {

            col.transform.position = new Vector3(-1000, -1000, -6f);
            scriptcomportamiento.agregar(col.gameObject);
            Proyectil proyectil = col.gameObject.GetComponent<Proyectil>();
            vidaenemigo -= proyectil.getdaño();
			au.clip = efectos [0];
			if (!au.isPlaying) {
				au.Play ();
			}
            if (vidaenemigo <= 0)
            {
                Destroy(gameObject);
            }
            
        }

    }

	public AudioClip[] getefectos(){
		return efectos;
	
	}

}
