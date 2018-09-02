using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour {

    public LayerMask capasuelo;
    public GameObject bomba;
    public GameObject explosion;
    public Transform circulo;

    VidaJoe scriptvida;
    GameObject jugador;
    public float tiempo;
    Rigidbody2D rigid;
    bool ensuelo;
    bool eliminar;
    AudioSource[] au;
    GameObject sonidos;

    

	void Awake () {
        jugador = GameObject.FindGameObjectWithTag("Player");
        scriptvida = jugador.GetComponent<VidaJoe>();
        sonidos = GameObject.Find("Sonidos");
        au = sonidos.GetComponents<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

        ensuelo = Physics2D.OverlapCircle(circulo.position, 2f, capasuelo);
        if (ensuelo) {
            tiempo += Time.deltaTime;
               
            
            if (tiempo >= 0.8f) {
                bomba.SetActive(false);
                if (explosion != null)
                {
                    explosion.transform.parent = null;
                    explosion.SetActive(true);
                   
                    au[0].Play();
                   
                    tiempo = 0f;
                    eliminar = true;  
                }
            }


        }

        if (eliminar) {
       
            Destroy(gameObject);
            
        }
        

	}

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            scriptvida.setvida(scriptvida.getvida() - 5f);
        }

        if (col.gameObject.name == "SueloBarco") {
            tiempo = 5f;
        }

    }

    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Bullet")
        {
    
            SpriteRenderer sprite = col.gameObject.GetComponent<SpriteRenderer>();
            if (sprite.flipX)
            {
                rigid.AddForce(new Vector2(-20f, 3f), ForceMode2D.Impulse);
            }
            else
            {
                rigid.AddForce(new Vector2(20f, 3f), ForceMode2D.Impulse);
            }

        }


    }

    public void settiempo(float tiempo) {
        this.tiempo = tiempo;
    }

}
