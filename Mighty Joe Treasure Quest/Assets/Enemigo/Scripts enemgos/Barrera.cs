using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrera : MonoBehaviour {

    /*Script básico que nos dice el daño que provoca la barrera, esta se pone debajo del nivel para cuando el jugador caiga 
     al vació*/
    private float daño = 10000f;

    public float getdaño() {
        return daño;
    }



}
