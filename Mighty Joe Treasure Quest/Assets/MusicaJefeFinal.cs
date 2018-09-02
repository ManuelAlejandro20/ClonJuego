using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaJefeFinal : MonoBehaviour {

    [SerializeField ]GameObject jefe;
    VidaJoe scriptvida;
    AudioSource au;

	void Awake () {

        Time.timeScale = 1;

        GameObject jugador = GameObject.FindGameObjectWithTag("Player"); ;
        scriptvida = jugador.GetComponent<VidaJoe>();
        au = GetComponent<AudioSource>();
    }
	
	
	void Update () {
        if (scriptvida.getvida() <= 0) {
            Destroy(gameObject);
        }
	}

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            jefe.SetActive(true);
            au.Play();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
