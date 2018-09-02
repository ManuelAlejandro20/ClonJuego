using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoJoe : MonoBehaviour {
 
    [SerializeField] bool ensuelo = true;
    [SerializeField] Transform chequearsuelo;
    
    bool disparo = false;
    float podersalto = 18f;
    float velocidad = 7f;
    float radiocirculosuelo = 1f;
    float tiempodisparo = 0f;
    float tiemposalto = 0f;
    int contadorderecha = 0;
    int contadorizquierda = 0;
    SpriteRenderer sprite;
    AnimatorStateInfo animatorInfo;
    Rigidbody2D rigid;
    Animator anim;
    float tiempobox;

    public LayerMask capasuelo;
    public GameObject proyectilprefab;
    public GameObject puñoprefab;
    
    void Awake() {

        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        
    }
 
    void Update() {
        //se llama al metodo "movimientos" el cual corresponde
        movimientos();

    }

    void movimientos() {
        //al presionar la tecla "z" se ejecutara el salto del personaje
        tiemposalto += 2f * Time.deltaTime;

        if (ensuelo && Input.GetKeyDown("z"))
        {
            anim.SetBool("parado", false);
            anim.SetTrigger("salto");
            rigid.velocity = new Vector2(rigid.velocity.x, 0f);
            rigid.AddForce(new Vector2(0, podersalto), ForceMode2D.Impulse);
            ensuelo = false;

        }

        if (tiemposalto >= 0.2f)
        {
            anim.SetBool("caer", false);
            tiemposalto = 0;
        }

        if (!ensuelo)
        {
            ensuelo = Physics2D.OverlapCircle(chequearsuelo.position, radiocirculosuelo, capasuelo);
            anim.SetBool("auxiliar caminando/salto", ensuelo);
          
        }

        ensuelo = Physics2D.OverlapCircle(chequearsuelo.position, radiocirculosuelo, capasuelo);
        anim.SetBool("parado", ensuelo);

        if (!ensuelo)
        {

            anim.SetBool("caer", true);
           

        }

        /*-----------------------------------------------------------------------------------------*/


        if (contadorderecha != 1 && Input.GetKey(KeyCode.RightArrow) && !anim.GetBool("agacharse") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Patada"))
        {
            sprite.flipX = false;
            anim.SetFloat("correr", 1f);
            anim.SetBool("parado", false);
            anim.SetBool("caminando", true);
            rigid.velocity = new Vector2(velocidad, rigid.velocity.y);
            contadorizquierda = 0;
        }

        if (contadorderecha != 1 && Input.GetKeyUp(KeyCode.RightArrow) && ensuelo && !anim.GetBool("patada"))
        {
            anim.SetFloat("correr", 0f);
            contadorderecha++;
            anim.SetBool("caminando", false);
            anim.SetBool("parado", true);
        }

        if (contadorizquierda != 1 && Input.GetKey(KeyCode.LeftArrow) && !anim.GetBool("agacharse") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Patada"))
        {
            sprite.flipX = true;
            anim.SetFloat("correr", 1f);
            anim.SetBool("parado", false);
            anim.SetBool("caminando", true);
            rigid.velocity = new Vector2(-velocidad, rigid.velocity.y);
            contadorderecha = 0;

        }

        if (contadorizquierda != 1 && Input.GetKeyUp(KeyCode.LeftArrow) && ensuelo && !anim.GetBool("patada"))
        {
            contadorizquierda++;
            anim.SetFloat("correr", 0f);
            anim.SetBool("caminando", false);
            anim.SetBool("parado", true);
        }

        if (contadorderecha >= 1 && Input.GetKey(KeyCode.RightArrow) && !anim.GetBool("agacharse") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Patada"))
        {
            if (sprite.flipX == true)
            {
                sprite.flipX = false;
            }
            anim.SetFloat("correr", 2.0f);
            anim.SetBool("parado", false);
            anim.SetBool("caminando", true);
            rigid.velocity = new Vector2(7 + velocidad, rigid.velocity.y);
            contadorderecha++;
        }

        else if (contadorderecha > 1 && Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetFloat("correr", 0f);
            anim.SetBool("caminando", false);
            anim.SetBool("parado", true);
            contadorderecha = 0;
        }

        if (contadorizquierda >= 1 && Input.GetKey(KeyCode.LeftArrow) && !anim.GetBool("agacharse") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Patada"))
        {
            if (sprite.flipX == false)
            {
                sprite.flipX = true;
            }

            anim.SetBool("parado", false);
            anim.SetFloat("correr", 2.0f);
            anim.SetBool("caminando", true);
            rigid.velocity = new Vector2(-7 + -velocidad, rigid.velocity.y);
            contadorizquierda++;

        }

        else if (contadorizquierda > 1 && Input.GetKeyUp(KeyCode.LeftArrow) && ensuelo && !anim.GetBool("patada"))
        {
            anim.SetBool("caminando", false);
            anim.SetFloat("correr", 0f);
            anim.SetBool("parado", true);
            contadorizquierda = 0;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("agacharse", true);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool("agacharse", false);
        }

        /*----------------------------------------------------------------------*/


        if (Input.GetKeyDown("x") && ensuelo && !disparo)
        {
            if (sprite.flipX == false)
            {
                rigid.velocity = new Vector2(-0.1f, rigid.velocity.y);
            }
            else
            {
                rigid.velocity = new Vector2(0.1f, rigid.velocity.y);
            }

            anim.SetBool("parado", true);
            anim.SetBool("caminando", false);
            anim.SetTrigger("puños");
        }

        else if (Input.GetKey("x") && ensuelo && !disparo) {
            tiempodisparo += Time.deltaTime;
            if (tiempodisparo >= 0.25f && !disparo)
            {
                if (sprite.flipX == false)
                {
                    rigid.velocity = new Vector2(2f, rigid.velocity.y);
                }
                else
                {
                    rigid.velocity = new Vector2(-2f, rigid.velocity.y);
                }

                anim.SetBool("parado", true);
                anim.SetBool("caminando", false);
                anim.SetTrigger("patada");
                disparo = true;
                tiempodisparo = 0f;
            }
        }

        if (Input.GetKeyUp("x"))
        {
            disparo = false;
            tiempodisparo = 0f;  
        }

        /*------------------------------------------------------*/

        animatorInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKeyDown("c") && anim.GetBool("parado"))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 15f);
            anim.SetTrigger("upper");
        }

        if (Input.GetKeyDown("c") && anim.GetBool("caminando") && ensuelo)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 15f);
            anim.SetTrigger("upper");
        }

        if (animatorInfo.IsTag("Salto") && Input.GetKeyDown("c")) {
            rigid.velocity = new Vector2(rigid.velocity.x, 15f);
            anim.SetTrigger("upper");
        }
    }


    void bala()
    {
        Instantiate(proyectilprefab, transform.position, Quaternion.identity);
    }

    void puño() {
        Instantiate(puñoprefab, transform.position, Quaternion.identity);
    }

    




}
