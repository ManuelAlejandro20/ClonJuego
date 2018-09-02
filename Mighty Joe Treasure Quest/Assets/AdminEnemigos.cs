using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminEnemigos : MonoBehaviour {

    public List<AudioClip> audios = new List<AudioClip>();

    public List<GameObject> go_enemigos = new List<GameObject>();
    public List<EnemigoSuelo> lista_enemigos = new List<EnemigoSuelo>();
    public List<EnemigoVolador> lista_enemigosvoladores = new List<EnemigoVolador>();

	void Awake () {
        foreach (GameObject go in go_enemigos) {
            if (go.tag == "Enemy")
            {
                go.AddComponent<EnemigoSuelo>();
                go.GetComponent<EnemigoSuelo>().inicializar(100f, 10f, go);
                lista_enemigos.Add(go.GetComponent<EnemigoSuelo>());
            }
            else {
                go.AddComponent<EnemigoVolador>();
                go.GetComponent<EnemigoVolador>().inicializar(100f,20f,go);
                lista_enemigosvoladores.Add(go.GetComponent<EnemigoVolador>());

            }

            
        }
        
    }
	
	void Update () {
		
	}

    public List<AudioClip> getAudios()
    {
        return this.audios;
    }
}
