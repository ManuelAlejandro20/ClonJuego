using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FondoMov : MonoBehaviour {

    public float velocidad_paralela;
    public RawImage fondo;

    float velocidadfinal;


	void Start () {
		
	}
	
	void Update () {

        velocidadfinal = velocidad_paralela * Time.deltaTime;
        fondo.uvRect = new Rect(fondo.uvRect.x + velocidadfinal, 0f, 1f, 1f);
       
	}
}
