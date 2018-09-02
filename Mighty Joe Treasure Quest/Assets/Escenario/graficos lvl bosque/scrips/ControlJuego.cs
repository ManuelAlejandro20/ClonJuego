using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlJuego : MonoBehaviour {

    public float parallaxSpeed = 0.07f;
    public float parallaxA = 0.07f;
    public float parallaxB = 0.07f;
    public float parallaxC = 0.01f;
    public RawImage Fondo;
    public RawImage Atras;
    public RawImage Medio;
    public RawImage Adelante;


    // Use this for initialization
    void Awake() {
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        float VelocidadFinal = parallaxSpeed * Time.deltaTime;
        float VelocidadFinalA = parallaxA * Time.deltaTime;
        float VelocidadFinalB = parallaxB * Time.deltaTime;
        float VelocidadFinalC = parallaxC * Time.deltaTime;
        Fondo.uvRect = new Rect(Fondo.uvRect.x + VelocidadFinal, 0f, 1f, 1f);
        Atras.uvRect = new Rect(Atras.uvRect.x + VelocidadFinalA, 0f, 1f, 1f);
        Medio.uvRect = new Rect(Medio.uvRect.x + VelocidadFinalB, 0f, 1f, 1f);
        Adelante.uvRect = new Rect(Adelante.uvRect.x + VelocidadFinalC, 0f, 1f, 1f);
    }
}
