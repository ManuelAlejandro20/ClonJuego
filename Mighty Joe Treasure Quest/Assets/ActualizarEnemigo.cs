using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActualizarEnemigo : MonoBehaviour {

    AudioSource au;

    void Awake() {
        au = GetComponent<AudioSource>();
    }
    public void sonido()
    {
        au.Play();
    }

    

}

public abstract class Enemigo : MonoBehaviour {

    [SerializeField]protected float vida;
    [SerializeField]protected float daño;
    [SerializeField]protected GameObject enemigo;


    public abstract void IA_moviemiento();

    public virtual void inicializar(float vida, float daño, GameObject enemigo) {
        this.vida = vida;
        this.daño = daño;
        this.enemigo = enemigo;
    }

    void FixedUpdate() {

        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public float getvida() {
        return this.vida;
    }

    public float getdaño() {
        return this.daño;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        ProyectilComportamiento proycomp = jugador.GetComponent<ProyectilComportamiento>();
        GameObject sonidos = GameObject.Find("AdminEnemigo");
        AdminEnemigos scriptadmin = sonidos.GetComponent<AdminEnemigos>();
        AudioSource au = sonidos.GetComponent<AudioSource>();
        if (col.tag == "Bullet")
        {
            col.transform.position = new Vector3(-1000, -1000, -6f);
            proycomp.agregar(col.gameObject);

            Proyectil proyectil = col.gameObject.GetComponent<Proyectil>();
            this.vida -= proyectil.getdaño();
            au.clip = scriptadmin.getAudios()[0];
            au.Play();

        }

        if (col.tag == "Uppercut") {
            au.clip = scriptadmin.getAudios()[1];
            au.Play();
            this.vida -= 80f;
        }

    }

}

public class EnemigoSuelo : Enemigo {

    [SerializeField] float velocidad = 5f;
    enum states { patrullar, acercarce, atacar, mirar }
    states estadoactual;

    GameObject jugador;
    Rigidbody2D rigidenemigo;
    Rigidbody2D rigid;
    SpriteRenderer sprite;



    Animator anim;

    Vector2 posicionfinal;
    Vector2 posicioninicial;

    bool moverseinicio = false;
    bool moversefinal = true;

    float distancia;
    float tiempoataque;

    public override void inicializar(float vida, float daño, GameObject enemigo)
    {
        base.inicializar(vida, daño, enemigo);
      
    }

    void Awake()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        rigidenemigo = GetComponent<Rigidbody2D>();
        rigid = jugador.GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        posicioninicial = rigidenemigo.position;
        posicionfinal = posicioninicial + new Vector2(-4f, 0f);
        estadoactual = states.patrullar;
    }

    void Update() {
        IA_moviemiento();
    }


    public override void IA_moviemiento()
    {
        if (rigid != null && rigidenemigo != null)
        {
            //distancia = Vector2.Distance(new Vector2(rigidenemigo.position.x, 0f), new Vector2(rigid.position.x, 0f));
            distancia = Vector2.Distance(rigid.position, rigidenemigo.position);
            switch (estadoactual)
            {

                case states.acercarce:

                    anim.SetTrigger("Caminata");

                    rigidenemigo.position = Vector2.MoveTowards(rigidenemigo.position, rigid.position, velocidad * Time.deltaTime);
                    if (rigid.position.x > rigidenemigo.position.x)
                    {
                        sprite.flipX = false;
                    }
                    else
                    {
                        sprite.flipX = true;
                    }

                    if (distancia < 4f)
                    {
                        estadoactual = states.atacar;
                    }

                    else if (distancia > 10f)
                    {
                        if (rigidenemigo.position.x > posicioninicial.x)
                        {
                            sprite.flipX = true;
                            moversefinal = true;
                            moverseinicio = false;
                        }

                        else
                        {

                            sprite.flipX = false;
                            moversefinal = false;
                            moverseinicio = true;

                        }

                        estadoactual = states.patrullar;
                    }


                    break;

                case states.atacar:
                    anim.SetTrigger("Ataque");
                    tiempoataque += Time.deltaTime;

                    if (tiempoataque >= 1f)
                    {
                        estadoactual = states.mirar;
                        tiempoataque = 0f;
                    }

                    break;

                case states.patrullar:

                    anim.SetTrigger("Caminata");

                    if (moversefinal)
                    {
                        sprite.flipX = true;
                        rigidenemigo.position = Vector2.MoveTowards(rigidenemigo.position, posicionfinal, velocidad * Time.deltaTime);
                        if (rigidenemigo.position == posicionfinal)
                        {
                            moverseinicio = true;
                            moversefinal = false;
                        }
                    }

                    if (moverseinicio)
                    {
                        sprite.flipX = false;
                        rigidenemigo.position = Vector2.MoveTowards(rigidenemigo.position, posicioninicial, velocidad * Time.deltaTime);
                        if (rigidenemigo.position == posicioninicial)
                        {
                            moversefinal = true;
                            moverseinicio = false;
                        }
                    }


                    if (distancia <= 10f)
                    {
                        estadoactual = states.acercarce;
                    }

                    break;

                case states.mirar:

                    if (distancia <= 4f)
                    {
                        estadoactual = states.atacar;
                    }
                    else if (distancia <= 10f && distancia > 4f)
                    {
                        estadoactual = states.acercarce;

                    }

                    else
                    {
                        if (rigidenemigo.position.x > posicioninicial.x)
                        {
                            sprite.flipX = true;
                            moversefinal = true;
                            moverseinicio = false;
                        }

                        else
                        {

                            sprite.flipX = false;
                            moversefinal = false;
                            moverseinicio = true;

                        }
                        estadoactual = states.patrullar;

                    }

                    break;



                default:
                    break;
            }

        }
    }

    public void OnCollisionEnter2D(Collision2D colo) {
        if (colo.gameObject.name == "Joe") {
            posicioninicial = rigidenemigo.position;
            posicionfinal = posicioninicial + new Vector2(-4f,0f);
        }
    }


}

public class EnemigoVolador : Enemigo {

    float velocidadflote = 6f;
    enum estados { mirar, prepararse, atacar, descender }
    estados estadoactual;
    float distancia;

    Rigidbody2D rigidenemigo;
    Rigidbody2D rigid;
    SpriteRenderer sprite;

    Vector2 posinicial;
    Vector2 poselevada;
    Vector2 posfinal;
    Vector2 posfinalsuelo;
    Vector2 puntocontrol;

    float count = 0.0f;

    Animator anim;

    void Awake()
    {
        estadoactual = estados.mirar;
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        rigid = jugador.GetComponent<Rigidbody2D>();
        rigidenemigo = GetComponent<Rigidbody2D>();
        posinicial = rigidenemigo.position;
        poselevada = posinicial + new Vector2(0f, 6f);
        posfinal = poselevada + new Vector2(-13f,0f);
        posfinalsuelo = posfinal + new Vector2(0f, -6f);
        puntocontrol = posfinal + new Vector2(4f,-10f);
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        IA_moviemiento();
    }

    public override void inicializar(float vida, float daño, GameObject enemigo)
    {
        base.inicializar(vida, daño, enemigo);

    }


    public override void IA_moviemiento()
    {
        if (rigid != null && rigidenemigo != null)
        {
            distancia = Vector2.Distance(rigid.position, rigidenemigo.position);
            switch (estadoactual)
            {
                case estados.mirar:
                    if (distancia < 12f)
                    {
                        anim.SetBool("Normal", false);
                        anim.SetBool("Alerta",true);
                        estadoactual = estados.prepararse;
                    }
                    break;
                case estados.prepararse:
                    
                    rigidenemigo.position = Vector2.MoveTowards(rigidenemigo.position, poselevada, velocidadflote * Time.deltaTime);
                    if (rigidenemigo.position == poselevada)
                    {
                        anim.SetBool("Ataque", true);
                        anim.SetBool("Alerta", false);
                        estadoactual = estados.atacar;
                    }
                    break;
                case estados.atacar:
                    if (count < 1.0f)
                    {
                        count += 1.0f * Time.deltaTime;

                        Vector2 m1 = Vector2.Lerp(poselevada, puntocontrol, count);
                        Vector2 m2 = Vector2.Lerp(puntocontrol, posfinal, count);
                        rigidenemigo.position = Vector2.Lerp(m1, m2, count);
                    }
                    if (rigidenemigo.position == posfinal) {
                        count = 0f;
                        estadoactual = estados.descender;
                        anim.SetBool("Ataque", false);
                        anim.SetBool("Alerta", true);
                    }

                    break;

                case estados.descender:
                    rigidenemigo.position = Vector2.MoveTowards(rigidenemigo.position, posfinalsuelo, velocidadflote * Time.deltaTime);
                    if (rigidenemigo.position == posfinalsuelo) {
                        anim.SetBool("Normal", true);
                        anim.SetBool("Alerta", false);
                        if (sprite.flipX)
                        {
                            sprite.flipX = false;
                        }
                        else
                        {
                            sprite.flipX = true;
                        }
                        Vector2 aux = posfinalsuelo;
                        posfinalsuelo = posinicial;
                        posinicial = aux;
                        aux = posfinal;
                        posfinal = poselevada;
                        poselevada = aux;
                        estadoactual = estados.mirar;


                    }

                    break;

                default:
                    break;

            }
        }
    }

}



