using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaPlataformas : MonoBehaviour
{

    Rigidbody2D rigidplat;
    Rigidbody2D rigidobjetivo;

    public float velocidad;
    public bool direccion;
    public GameObject objetivo;

    public bool moverse;

    void Awake()
    {
        rigidplat = GetComponent<Rigidbody2D>();
        rigidobjetivo = objetivo.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (moverse) {

            rigidplat.position = Vector2.MoveTowards(rigidplat.position, rigidobjetivo.position, velocidad * Time.deltaTime);
            if (rigidplat.position == rigidobjetivo.position) {
                moverse = false;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            moverse = true;
        }

    }

}