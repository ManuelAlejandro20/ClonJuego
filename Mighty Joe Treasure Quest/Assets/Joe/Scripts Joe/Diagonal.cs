using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diagonal : MonoBehaviour {

	GameObject jugador;
	Animator anim;
	bool ensuelo;
	public LayerMask sueloinclinado;
	public Transform chequearsuelo;
	SpriteRenderer sprite;

	void Awake(){

		jugador = GameObject.FindGameObjectWithTag ("Player");
		anim = jugador.GetComponent<Animator> ();
		sprite = jugador.GetComponent<SpriteRenderer> ();
	}

	void Update(){

	

	}

	public void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag == "SueloInclinado") {

			if (sprite.flipX) {
				anim.SetFloat ("Estado", 1f);
			} else {
			
				anim.SetFloat ("Estado", 0.5f);

			}
		
		}
	
	
	
	}

	public void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "SueloInclinado") {

			anim.SetFloat ("Estado", 0f);

		}


	
	}

}
