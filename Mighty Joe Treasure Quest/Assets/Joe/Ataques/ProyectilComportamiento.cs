using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilComportamiento : MonoBehaviour
{

    public int total;
    public GameObject prefabbala;
    public GameObject prefabpatada;

    Rigidbody2D rigid;
    SpriteRenderer sprite;


    public List<GameObject> balas = new List<GameObject>();
    public List<GameObject> patadas = new List<GameObject>();

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        for (int i = 0; i < total; i++)
        {
            GameObject bala = Instantiate(prefabbala, new Vector3(-1000, -1000, -6f), Quaternion.identity);
            GameObject patada = Instantiate(prefabpatada, new Vector3(-1000, -1000, -6f), Quaternion.identity);
            //patada.transform.SetParent(transform);
            //bala.transform.SetParent(transform);
            patadas.Add(patada);
            balas.Add(bala);
        }
    }

    void Update()
    {

    }

    IEnumerator ReUseBullet(GameObject proyectil)
    {
        Proyectil scriptproyectil = proyectil.GetComponent<Proyectil>();
        yield return new WaitForSeconds(scriptproyectil.getduracion());
        proyectil.transform.position = new Vector3(-1000, -1000, -6f);
        agregar(proyectil);
        
    }

    void puñoproyectil()
    {
        GameObject bala = balas[0];
        proyectil_comportamiento(bala);
        balas.RemoveAt(0);
        StartCoroutine(ReUseBullet(bala));

    }

    void patadaproyectil()
    {
        GameObject patada = patadas[0];
        proyectil_comportamiento(patada);
        patadas.RemoveAt(0);
        StartCoroutine(ReUseBullet(patada));
    }

    void proyectil_comportamiento(GameObject proyectil){
        Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
        Proyectil scriptproyectil = proyectil.GetComponent<Proyectil>();
        AudioSource au = proyectil.GetComponent<AudioSource>();
        au.Play();
        SpriteRenderer spritebala = proyectil.GetComponent<SpriteRenderer>();
        if (rigid != null)
        {
            rb.position = rigid.position;

            if (!sprite.flipX)
            {
                spritebala.flipX = false;
                rb.velocity = new Vector2(scriptproyectil.getvelocidad(), rigid.velocity.y);
            }
            else
            {

                spritebala.flipX = true;
                rb.velocity = new Vector2(-scriptproyectil.getvelocidad(), rigid.velocity.y);

            }
        }

    }

    public void agregar(GameObject proyectil) {
        if (proyectil.name == "Puño(Clone)")
        {
            balas.Add(proyectil);
        }
        else
        {
            patadas.Add(proyectil);
        }
    }



}
