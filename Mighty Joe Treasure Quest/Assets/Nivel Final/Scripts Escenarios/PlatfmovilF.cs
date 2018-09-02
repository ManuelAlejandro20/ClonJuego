using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfmovilF : MonoBehaviour {

    public float velocidad;
    public Vector3 principio;
    public Vector3 fin;

    Rigidbody2D rigid, rigid_objetivo, rigidjug;

    GameObject jugador;

    bool plat;

    public float distancia;

    void Awake()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
        //rigid = GetComponent<Rigidbody2D>();
        //rigid_objetivo = objetivo.GetComponent<Rigidbody2D>();
        jugador = GameObject.FindGameObjectWithTag("Player");
        //rigidjug = jugador.GetComponent<Rigidbody2D>();
        
    }

    float tiempo = 0;

    void Start()
    {
        //principio = rigid.position;
        //fin = rigid_objetivo.position;
        principio = new Vector3(transform.position.x, transform.position.y, -1f);
        fin = principio + new Vector3(-distancia,0f,0f); 
        plat = false;
    }

    void FixedUpdate()
    {
        
        tiempo += Time.fixedDeltaTime;
        if (gameObject != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, fin , velocidad * Time.fixedDeltaTime);

        }
        if (tiempo >= 3)
        {
            if (fin == principio)
            {
                fin = principio + new Vector3(-distancia, 0f, 0f);
            }
            else {
                fin = principio;
            }

            tiempo = 0f;
        }

        if (jugador != null)
        {

            if (plat)
            {
                jugador.transform.parent = transform;
                

            }
            else
            {

                jugador.transform.parent = null;

            }


        }

        /*if (rigidjug.transform.parent == transform) {
            rigidjug.velocity = new Vector2(velocidad, 0f);
        }*/



    }

    public void OnCollisionStay2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.parent = transform;
            plat = true;
        }
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.parent = null;
            plat = false;
        }

    }
}

