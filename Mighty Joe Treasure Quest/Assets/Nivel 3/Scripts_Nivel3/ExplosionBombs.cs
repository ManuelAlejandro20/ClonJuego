using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBombs : MonoBehaviour
{

    VidaJoe scriptvida;
    GameObject jugador;

    void Awake()
    {

        jugador = GameObject.FindGameObjectWithTag("Player");
        scriptvida = jugador.GetComponent<VidaJoe>();

    }

    public void bomba()
    {
       
       Destroy(gameObject);
        
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            scriptvida.setvida(scriptvida.getvida() - 20f);
        }

    }

}