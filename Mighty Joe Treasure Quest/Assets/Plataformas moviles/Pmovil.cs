using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pmovil : MonoBehaviour {

	public GameObject objetivo;
	public float velocidad;
	Vector2 principio, fin;

	Rigidbody2D rigid, rigid_objetivo, rigidjug;

	GameObject jugador;

	public bool plat;

	void Awake()
	{

		rigid = GetComponent<Rigidbody2D>();
		rigid_objetivo = objetivo.GetComponent<Rigidbody2D>();
		jugador = GameObject.FindGameObjectWithTag ("Player");
		rigidjug = jugador.GetComponent<Rigidbody2D> ();
	}


	void Start()
	{
		principio = rigid.position;
		fin = rigid_objetivo.position;
		plat = false;
	}

	void FixedUpdate()
	{



		if (rigid != null)
		{
			rigid.position = Vector2.MoveTowards(rigid.position, rigid_objetivo.position, velocidad);



		}
		if (rigid.position == rigid_objetivo.position)
		{
			rigid_objetivo.position = (rigid_objetivo.position == principio) ? fin : principio;
		}


		if (rigidjug != null) {

			if (plat) {
				rigidjug.transform.parent = transform;


			} else {

				rigidjug.transform.parent = null;

			}


		}



	}

	public void OnCollisionStay2D(Collision2D col){

		if(col.gameObject.tag == "Player"){
			col.gameObject.transform.parent = rigid.transform;
			plat = true;
		}
	}

	public void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.transform.parent = null;
			plat = false;
		}

	}



}