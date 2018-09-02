using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingTroopers : MonoBehaviour {

    public GameObject principio;
    public GameObject final;
    public float velocidad;
    public float rango;

    float tiempo; 




    Rigidbody2D rigid;
    Rigidbody2D rigidinicio;
    Rigidbody2D rigidfinal;

    bool muertos;


    SpriteRenderer sprite;

    bool haciafinal;
    bool haciainicio;

    void Awake() {

        rigid = GetComponent<Rigidbody2D>();
        rigidinicio = principio.GetComponent<Rigidbody2D>();
        rigidfinal = final.GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        muertos = VidaFT.muerto;
        if (muertos) {
            gameObject.SetActive(false);
        }
    }
    

	void Start () {

        rigid.position = rigidinicio.position;
        haciafinal = true;
	}
	
	
	void Update () {

        if (haciafinal)
        {
            sprite.flipX = false;
            rigid.position = Vector3.MoveTowards(rigid.position, rigidfinal.position, velocidad);
            if (rigid.position == rigidfinal.position) {
                tiempo += Time.deltaTime;
                if (tiempo >= 5.5f)
                {
                    rigidinicio.position = new Vector2(rigidinicio.position.x, Random.Range(-rango, rango));
                    haciafinal = false;
                    haciainicio = true;
                    tiempo = 0;
                }
            }

        }
        else if(haciainicio) {

            sprite.flipX = true;
            rigid.position = Vector3.MoveTowards(rigid.position, rigidinicio.position, velocidad);
            if (rigid.position == rigidinicio.position)
            {
                tiempo += Time.deltaTime;
                if (tiempo >= 5.5f)
                {
                    rigidfinal.position = new Vector2(rigidfinal.position.x, Random.Range(-rango, rango));
                    haciafinal = true;
                    haciainicio = false;
                    tiempo = 0;
                }
            }
        }
       



    }
}
