using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platfmovil : MonoBehaviour {
    public Transform objetivo;
    public float speed;
    private Vector3 principio, fin;
	// el objetivo se hace de clase hijo de la Platmovil
	void Start () {
        if (objetivo != null)
        {
            objetivo.parent = null;
            principio = transform.position;
            fin = objetivo.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // cada vez que la plataforma llegue al objetivo este modifica su posicion a la inicial de la plataforma
    // para que asi la plataforma tenga un movimiento ciclico
    private void FixedUpdate()
    {
        float Fixedspeed = speed * Time.deltaTime;
        if(objetivo != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, objetivo.position, Fixedspeed);
        }
        if (transform.position == objetivo.position)
        {
            Debug.Log("xdddd");
            objetivo.position = (objetivo.position == principio) ? fin : principio;
        }
        
    }
}
