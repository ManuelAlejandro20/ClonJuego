using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viento : MonoBehaviour {

    Rigidbody2D rigid;
    int direccionviento;
    public float tiempo;
    public float cantidad;
	public float tiempolimite;
	bool direccion;

    void Awake() {

        rigid = GetComponent<Rigidbody2D>();

    }


	void Start () {
		
	}

	void Update () {


        tiempo += Time.deltaTime;
		if (tiempo >= tiempolimite) {

            if (!direccion)
            {
                this.direccionviento = Random.Range(1, 3);
                direccion = true;
            }
            if (direccionviento == 2)
            {
                if (rigid != null) {
                    rigid.AddForce(new Vector2(-cantidad, 0.2f), ForceMode2D.Impulse);
                }
                if (tiempo >= tiempolimite + 4f)
                {
                    tiempo = 0;
                    direccion = false;
                }
            }
            else {
                if (rigid != null)
                {
                    rigid.AddForce(new Vector2(cantidad, 0.2f), ForceMode2D.Impulse);
                }
                if (tiempo >= tiempolimite + 4f)
                {
                    tiempo = 0;
                    direccion = false;
                }




            }

            if (tiempo == 0) {
                this.direccionviento = 0;

            }

        }

       

	}

    public int getdireccionviento() {
        return direccionviento;
    }
}
