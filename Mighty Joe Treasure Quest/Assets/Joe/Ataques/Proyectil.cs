using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {

    public float daño;
    public float velocidad;
    public float duracion;

    

    void Awake() {
        
    }

    public float getdaño() {
        return this.daño;
    }

    public float getduracion() {
        return this.duracion;
    }

    public float getvelocidad() {
        return this.velocidad;
    }

}
