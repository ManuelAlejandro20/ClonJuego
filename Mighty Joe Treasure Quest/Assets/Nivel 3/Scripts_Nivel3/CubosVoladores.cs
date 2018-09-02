using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubosVoladores : MonoBehaviour {

	Rigidbody2D rigid;
	float tiempo;
	public float velocidad;
	bool arriba = true;
	public float cambiotiempo; 

	void Awake(){

		rigid = GetComponent<Rigidbody2D> ();

	}




	void Start () {
		
	}

	void Update () {
		
		if (Time.timeScale == 1) {
			tiempo += Time.deltaTime;
			if (arriba) {
				rigid.position = new Vector2 (rigid.position.x, rigid.position.y + velocidad);
				if (tiempo > cambiotiempo) {
					arriba = false;
					tiempo = 0f;
				}
			} else if (!arriba) {
				rigid.position = new Vector2 (rigid.position.x, rigid.position.y - velocidad);
				if (tiempo > cambiotiempo) {
					tiempo = 0f;
					arriba = true;
				}
			}
		}

	}
}
