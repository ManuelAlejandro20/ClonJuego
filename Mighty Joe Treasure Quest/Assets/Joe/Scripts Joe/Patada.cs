using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patada : MonoBehaviour
{
    private Rigidbody2D bala;
    private GameObject jugador;

    public float bulletspeed;
    public float duracion;
    public static float daño;
    public float dañoref;
    SpriteRenderer sprite;
    Rigidbody2D rigid;

    


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        daño = dañoref;
        jugador = GameObject.FindGameObjectWithTag("Player");
        /*Aqui se detecta si el ataque usado es el Uppercut*/
    }

    /*El proyectil se comporta de manera distinta si es un Uppercut o un ataque de patadas y puños*/
    void Start()
    {

        if (jugador.GetComponent<SpriteRenderer>().flipX == false)
        {
            if (sprite.flipX == true)
            {
                sprite.flipX = false;
            }
            rigid.velocity = new Vector2(bulletspeed, rigid.velocity.y);

        }
        else
        {

            rigid.velocity = new Vector2(-bulletspeed, rigid.velocity.y);
            sprite.flipX = true;
        }


        rigid.velocity = new Vector2(rigid.velocity.x, bulletspeed);

    }

    /*El proyectil se destruye pasado un tiempo*/
    void Update()
    {

        Destroy(gameObject, duracion);
    }

    /*El proyectil se destruirá si choca con un enemigo*/
    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Enemy")
        {

            Destroy(gameObject);

        }
    }

    

}
