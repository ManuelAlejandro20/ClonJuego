using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour {

    /*Esta imagen corresponde a la barra de vida*/
    public Image barra;

    VidaJoe scriptvida;
    GameObject jugador;

    /*Se obtiene al jugador y al script de la vida del jugador*/
    void Awake() {
        jugador = GameObject.FindGameObjectWithTag("Player");
        scriptvida = jugador.GetComponent<VidaJoe>();
    }

	void Update () {

        vidabarra(scriptvida.getvida());

	}

    /*Con esta función la vida cambiará la barra de vida que esta en el juego */
    void vidabarra(float vida) {

        barra.fillAmount = (vida/100f);

    }
}
