using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientoenemigo : MonoBehaviour
{

    private enum states { caminata, ataque }
    private states estadoprincipal;
	AudioSource au;
	EnemyHealth script;
	AudioClip[] efectos;

    public float velocidadenemigo;
    public Transform puntopartida;
    public Transform puntofinal;
    public Transform localizador;
    public float distanciaacercamiento;
    public int daño;

    float distancia;
    bool persiguiendo = false;
    Animator anim;
    SpriteRenderer sprite;
    Transform jugador;

    void Awake()
    {
		au = GetComponent<AudioSource> ();
		script = GetComponent<EnemyHealth> ();
		efectos = script.getefectos ();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        estadoprincipal = states.caminata;
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start() {

        if (sprite.flipX == false)
        {
            transform.position = puntopartida.transform.position;

        }
        else
        {

            transform.position = puntofinal.transform.position;

        }

    }

    void Update()
    {   //se activan los metodos del movimiento de enemigo
        acercamiento();
        IA();
    }

    void IA() {

        switch (estadoprincipal){
            //se definen los puntos de donde hasta donde se movera el enemigo dentro de la escena
            case states.caminata:
                if (!persiguiendo)
                {
                    anim.SetTrigger("Caminata");
                    if (sprite.flipX == false)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, puntofinal.transform.position, velocidadenemigo * Time.deltaTime);
                        if (transform.position == puntofinal.transform.position)
                        {
                            sprite.flipX = true;
                        }

                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, puntopartida.transform.position, velocidadenemigo * Time.deltaTime);
                        if (transform.position == puntopartida.transform.position)
                        {
                            sprite.flipX = false;
                        }

                    }
                }
                break;


            case states.ataque:
                //se activara la animacion de ataque de enemigo cuando el jugador se encuentre en el territorio del enemigo
                if (distancia <= distanciaacercamiento) {
					au.clip = efectos[1];
					if (!au.isPlaying) {
						au.Play ();
					}
                    if ((jugador.position.x - transform.position.x) > 1)
                    {
                        sprite.flipX = false;
                        anim.SetTrigger("Ataque");
                        localizador.transform.position = new Vector2(jugador.transform.position.x - 3.3f, puntofinal.transform.position.y);
                        transform.position = Vector3.MoveTowards(transform.position, localizador.transform.position, velocidadenemigo * Time.deltaTime);

                    }
                    else if ((jugador.position.x - transform.position.x) < 1)
                    {
                        sprite.flipX = true;
                        anim.SetTrigger("Ataque");
                        localizador.transform.position = new Vector2(jugador.transform.position.x + 3.3f, puntofinal.transform.position.y);
                        transform.position = Vector3.MoveTowards(transform.position, localizador.transform.position, velocidadenemigo * Time.deltaTime);

                    }

                }
                break;




            default:
                break;
        }
    }

    void acercamiento() {
        //el enemigo se movera hacia el jugador si es que este esta a su alcance
        distancia = Vector3.Distance(jugador.position, transform.position);
        if (distancia <= distanciaacercamiento)
        {
            estadoprincipal = states.ataque;
            persiguiendo = true;

        }
        else if (persiguiendo) {

            anim.SetTrigger("Caminata");
            transform.position = Vector3.MoveTowards(transform.position, puntofinal.transform.position, velocidadenemigo * Time.deltaTime);

            if (transform.position.x > puntofinal.transform.position.x)
            {
                sprite.flipX = true;
            }

            else if (transform.position.x < puntofinal.transform.position.x)
            {
                sprite.flipX = false;

            }
           
            if (transform.position == puntofinal.transform.position)
            {
                persiguiendo = false;
                estadoprincipal = states.caminata;
            }

        }


    }
    //se retornara el daño ejercido por el enemigo
    public int getdaño() {
        return daño;
    }
}
