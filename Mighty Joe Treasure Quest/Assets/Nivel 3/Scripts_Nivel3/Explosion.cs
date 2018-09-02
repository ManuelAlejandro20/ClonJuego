using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public GameObject[] explosiones;
    float tiempo;

	void Start () {
		
	}
	
	
	void Update () {

        tiempo += Time.deltaTime;
        explosiones[0].SetActive(true);
        if (tiempo >= 0.4f) {
            explosiones[1].SetActive(true);
        }
        if (tiempo >= 0.8f) {
            explosiones[2].SetActive(true);
        }
        if (tiempo >= 1.2f)
        {
            explosiones[3].SetActive(true);
        }
        if (tiempo >= 1.6f)
        {
            explosiones[4].SetActive(true);
        }



    }
}
