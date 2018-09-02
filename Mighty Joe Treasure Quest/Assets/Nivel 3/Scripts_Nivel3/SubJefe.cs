using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubJefe : MonoBehaviour
{

    public LayerMask capasuelo;
    public Transform Circulo;
    public float velocidad;
    public float vibracion;
    public GameObject prefabbomba;
    public Transform izquierda;
    public Transform derecha;
    


    public float tiemposuelo;
    public float tiemposubida;
    float tiempocamara = 0.6f;
    Rigidbody2D rigid;
    Rigidbody2D rigidjug;
    /*PolygonCollider2D[] pol;*/
    GameObject ft;
    GameObject camara;
    GameObject jugador;
    RectTransform rect;
    Viento scriptviento;
    AudioSource[] au;

    SpriteRenderer sprite;
    int numeroataque = 0;
    bool sonidotiembla = false;
    bool ensuelo;
    bool estaarriba = true;
    public bool subir = false;
    bool haciajoe = false; 

    bool temblar = false;
    bool ataque = false;
    bool aux = false;

    void Awake()
    {
        camara = GameObject.Find("Main Camera");
        rect = camara.GetComponent<RectTransform>();
        ft = GameObject.Find("FlyingTroopers");
        /*pol = ft.GetComponents<PolygonCollider2D>();*/
        rigid = ft.GetComponent<Rigidbody2D>();
        jugador = GameObject.FindGameObjectWithTag("Player");
        rigidjug = jugador.GetComponent<Rigidbody2D>();
        sprite = ft.GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
        au = GetComponents<AudioSource>();
    }


    void FixedUpdate()
    {
        
        ensuelo = Physics2D.OverlapCircle(Circulo.position, 0.3f, capasuelo);

        if (estaarriba)
        {
            rigid.bodyType = RigidbodyType2D.Dynamic;
            if (!au[0].isPlaying)
            {
                au[0].Play();
            }
            if (ensuelo)
            {
                rigid.bodyType = RigidbodyType2D.Static;
                estaarriba = false;
            }
        }

        if (ensuelo && !subir)
        {
            tiemposuelo += Time.fixedDeltaTime;
            ataque = true;
            if (tiemposuelo >= 4f)
            {
                ataque = false;
                numeroataque = 0;
                tiemposuelo = 0f;
                subir = true;
                
            }

        }

        if (ensuelo && !aux)
        {
            temblar = true;
            aux = true;
        }

        camaratiembla();

        if (subir)
        {
            aux = false;
            rigid.bodyType = RigidbodyType2D.Dynamic;
            tiemposubida += Time.fixedDeltaTime;
            rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y + 0.6f);
            if (tiemposubida >= 1.5f)
            {
                tiemposubida = 0f;
                subir = false;
                haciajoe = true;
                rigid.bodyType = RigidbodyType2D.Static;

            }
        }

        if (haciajoe && !ensuelo)
        {
            if (rigidjug != null)
            {
                float posx = rigidjug.position.x;
                int posxint = Mathf.RoundToInt(posx);
                if (posx < rigid.position.x)
                {
                    rigid.position = new Vector2(rigid.position.x - 0.4f, rigid.position.y);
                    sprite.flipX = true;
                }
                else
                {
                    rigid.position = new Vector2(rigid.position.x + 0.4f, rigid.position.y);
                    sprite.flipX = false;
                }

                int rigidint = Mathf.RoundToInt(rigid.position.x);

                if (rigidint == posxint)
                {
                    estaarriba = true;
                    haciajoe = false;
                }
            }


        }


        if (ataque)
        {

            if (numeroataque == 0)
            {
                numeroataque = Random.Range(1, 4);
            }

            Bomba[] bombas = FindObjectsOfType<Bomba>();
            int cuenta = bombas.Length;
            int num = Random.Range(1, 4);
            int potencia = Random.Range(2,16);

            if (numeroataque == 1)
            {

                if (cuenta < 3)
                {
                    if (num == 1)
                    {
                        GameObject clon = Instantiate(prefabbomba, izquierda.position, Quaternion.identity);
                        Rigidbody2D rigidbomba = clon.GetComponentInChildren<Rigidbody2D>();
                        rigidbomba.AddForce(new Vector2(-potencia, 2f), ForceMode2D.Impulse);
                    }
                    else
                    {
                        GameObject clon = Instantiate(prefabbomba, derecha.position, Quaternion.identity);
                        Rigidbody2D rigidbomba = clon.GetComponentInChildren<Rigidbody2D>();
                        rigidbomba.AddForce(new Vector2(potencia, 2f), ForceMode2D.Impulse);

                    }
                }
            }
            else if (numeroataque == 2)
            {

                if (cuenta < 1)
                {
                    if (num == 1)
                    {
                        GameObject clon = Instantiate(prefabbomba, izquierda.position, Quaternion.identity);
                        Rigidbody2D rigidbomba = clon.GetComponentInChildren<Rigidbody2D>();
                        rigidbomba.AddForce(new Vector2(-10f, 2f), ForceMode2D.Impulse);
                    }
                    else
                    {
                        GameObject clon = Instantiate(prefabbomba, derecha.position, Quaternion.identity);
                        Rigidbody2D rigidbomba = clon.GetComponentInChildren<Rigidbody2D>();
                        rigidbomba.AddForce(new Vector2(10f, 2f), ForceMode2D.Impulse);

                    }
                }
            }


        }

    }

    void camaratiembla()
    {
        if (temblar)
        {
            if (!sonidotiembla)
            {
                au[1].Play();
                sonidotiembla = true;
            }
            Vector3 posini = rect.position;
            if (tiempocamara > 0f)
            {
                Vector2 vector = Random.insideUnitSphere * vibracion;
                rect.position = new Vector3(rect.position.x + vector.x, rect.position.y + vector.y, -10f);
                tiempocamara -= Time.fixedDeltaTime;
            }
            else
            {
                rect.position = posini;
                tiempocamara = 0.6f;
                temblar = false;
                sonidotiembla = false;
            }
        }
    }

}