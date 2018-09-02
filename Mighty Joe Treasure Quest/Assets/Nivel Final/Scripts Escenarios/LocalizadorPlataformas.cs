using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizadorPlataformas : MonoBehaviour {

    public List<GameObject> plataformas;
    public List<Vector3> posiciones;

    void Awake() {
        foreach (GameObject plataformas in plataformas) {
            posiciones.Add(plataformas.transform.position);
        }
    }

    void Update() {

    }

    public void OnTriggerEnter2D(Collider2D col) {

        if (col.gameObject.tag == "Player" || col.name == "Joe") {
            for (int i = 0; i < plataformas.Capacity; i++)
            {
                plataformas[i].transform.position = posiciones[i];

            }
        }
    }

}
