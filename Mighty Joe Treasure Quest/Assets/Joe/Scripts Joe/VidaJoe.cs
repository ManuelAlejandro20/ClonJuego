using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaJoe : MonoBehaviour
{

    public static float vidajoe = 100f;
    float vidajoe2 = 100f;


    AudioSource au;
    AudioSource[] aus;
    public AudioClip[] efectos;
    public Canvas terminojuego;
    public Text textovidas;


    static int vidas = 3;
    float tiempo;

    GameObject enemigo;
    Enemigo scriptenemigo;

    GameObject barrera;
    Barrera barreramuerte;

    Transform jugador;
    BoxCollider2D box;
    MoJoe script;
    SpriteRenderer sprite;
    Rigidbody2D rigid;
    Animator anim;

    Canvas canvasgameover;

    int escenaactual;

    float tiempobox;

    bool musica_gameover;
    bool boolaux = true;
    void Awake()
    {

        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        au = GetComponent<AudioSource>();
        aus = GetComponents<AudioSource>();
        rigid = jugador.GetComponent<Rigidbody2D>();
        box = jugador.GetComponent<BoxCollider2D>();
        script = jugador.GetComponent<MoJoe>();
        sprite = jugador.GetComponent<SpriteRenderer>();
        anim = jugador.GetComponent<Animator>();
        textovidas.text = "x " + (vidas - 1);
        canvasgameover = terminojuego.GetComponent<Canvas>();
        escenaactual = SceneManager.GetActiveScene().buildIndex;

    }

    void Update()
    {
        //si es que joe llega a perder una vida, se reiniciara el juego con el descuento de una vida
        if (vidajoe <= 0 && !anim.GetBool("muertosuelo"))
        {
            anim.SetTrigger("muerto");
            anim.SetBool("muertosuelo", true);
            au.clip = efectos[1];
            au.Play();
            vidas--;
            if (vidas == 0)
            {
                textovidas.text = "x " + 0;
            }

            else
            {
                textovidas.text = "x " + (vidas - 1);
            }

            if (sprite.flipX == false)
            {
                rigid.AddForce(new Vector2(-36f, 6f), ForceMode2D.Impulse);

            }
            else
            {

                rigid.AddForce(new Vector2(36f, 6f), ForceMode2D.Impulse);
            }

            Destroy(box);
            Destroy(rigid);
            Destroy(script);
            

        }


        //si joe pierde todas las vidas se devolvera la pantalla inicial de juego
        if (anim.GetBool("muertosuelo"))
        {
            tiempo += Time.deltaTime;
            if (tiempo >= 2.5f)
            {
                if (vidas == 0)
                {
                    musica_gameover = true;
                    Time.timeScale = 0;
                    canvasgameover.enabled = true;
                    if (Input.GetKeyDown("x"))
                    {

                        vidajoe = vidajoe2;
                        vidas = 3;
                        canvasgameover.enabled = false;
                        Time.timeScale = 1;
                        SceneManager.LoadScene(0);

                    }
                }
                else
                {

                    vidajoe = vidajoe2;
                    if (escenaactual >= 1 && escenaactual <= 3)
                    {
                        SceneManager.LoadScene(1);
                    }
                    else if (escenaactual >= 4 && escenaactual <= 9)
                    {
                        SceneManager.LoadScene(4);
                    }
                    else if (escenaactual >= 10 && escenaactual <= 14)
                    {
                        SceneManager.LoadScene(10);
                    }
                    else if (escenaactual >= 15 && escenaactual <= 16)
                    {
                        SceneManager.LoadScene(15);
                    }





                }
            }

        }

        if (musica_gameover && boolaux)
        {
            aus[1].Play();
            boolaux = false;

        }

        if (Physics2D.GetIgnoreLayerCollision(0, 0))
        {
            tiempobox += Time.deltaTime;
            if (tiempobox >= 1.2f)
            {
                Physics2D.IgnoreLayerCollision(0, 0, false);
                tiempobox = 0f;
                sprite.color = new Color(1f, 1f, 1f, 1f);
            }
        }


    }

    void FixedUpdate()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //si es que el enemigo ejecuta daño a Joe a este se le reducira la vida
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemigoVolador" && vidajoe > 0)
        {
            enemigo = col.gameObject;
            scriptenemigo = enemigo.GetComponent<Enemigo>();
            au.clip = efectos[0];
            au.Play();
            anim.SetTrigger("daño");

            Physics2D.IgnoreLayerCollision(0, 0);
            sprite.color = new Color(1f, 1f, 1f, .5f);


            if (sprite.flipX == false)
            {
                rigid.AddForce(new Vector2(-16f, 6f), ForceMode2D.Impulse);

            }
            else
            {

                rigid.AddForce(new Vector2(16f, 6f), ForceMode2D.Impulse);
            }

            if (scriptenemigo != null)
            {
                vidajoe -= scriptenemigo.getdaño();
            }
        }
        //la barra de vida será reducida según el daño
        if (col.gameObject.tag == "Barrera" && vidajoe > 0)
        {
            barrera = col.gameObject;
            barreramuerte = barrera.GetComponent<Barrera>();
            vidajoe -= barreramuerte.getdaño();
        }

        if (col.gameObject.name == "Proyectil(Clone)") {
            GameObject proyectil = col.gameObject;
            Proyectil scriptproyectil = proyectil.GetComponent<Proyectil>();
            vidajoe -= scriptproyectil.getdaño();
        }

        if (col.gameObject.name == "Hueso")
        {
            GameObject proyectil = col.gameObject;
            VidaJefeFinal script = proyectil.GetComponentInParent<VidaJefeFinal>();
            vidajoe -= script.getDañoHueso();
        }

    }

    public void OnTriggerEnter2D(Collider2D colo)
    {
        if (colo.name == "SueloBarco")
        {
            vidajoe -= 100f;
        }


    }


    //se retorna la vida de joe
    public float getvida()
    {
        return vidajoe;
    }

    public int getvida1up()
    {
        return vidas;

    }

    public void setvida(float vidanueva)
    {
        vidajoe = vidanueva;
    }

    public void setvida1up(int numvidas)
    {

        vidas = numvidas;

    }

    void Uppercut()
    {
        if (Physics2D.GetIgnoreLayerCollision(0, 0))
        {
            tiempobox += Time.deltaTime;
            if (tiempobox >= 0.5f)
            {
                Physics2D.IgnoreLayerCollision(0, 0, false);
                tiempobox = 0f;
            }
        }

        else
        {
            Physics2D.IgnoreLayerCollision(0, 0);
        }
    }
}
