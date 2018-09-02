using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Confirmador_escenas : MonoBehaviour {

    GameObject jugador;
    VidaJoe scriptvida;
    Rigidbody2D rigid;
    GameObject camara;
    RectTransform rect;

    static int escena_actualest;
    int escena_actual;

    static bool cambiar_escena = false;

    void Awake() {

        

        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Update() {


        escena_actual = SceneManager.GetActiveScene().buildIndex;

        if (escena_actual == 0)
        {
            Destroy(this.gameObject);
        }

        if (jugador == null) {
            jugador = GameObject.FindGameObjectWithTag("Player");
            rigid = jugador.GetComponent<Rigidbody2D>();
            scriptvida = jugador.GetComponent<VidaJoe>();
            camara = GameObject.Find("Main Camera");
            rect = camara.GetComponent<RectTransform>();
        }


        if (!cambiar_escena) {

            escena_actualest = escena_actual;
            cambiar_escena = true;

        }

        if (escena_actual != escena_actualest) {
            cambiar_escena = false;
        }

        if (scriptvida.getvida() <= 0)
        {
            cambiar_escena = false;
        }

        

        posicionjoe();

        if (scriptvida.getvida1up() == 0)
        {
            Destroy(gameObject);
        }

    }

    void posicionjoe() {

        if (escena_actual >= 1 && escena_actual <=3) {
            if (escena_actualest == escena_actual + 1)
            {
                if (escena_actual == 1)
                {

                    rigid.position = new Vector2(40.37843f, 2.903742f);
                    camara.transform.position = new Vector3(28.6f, 2.86374f, -10f);

                }

                else if (escena_actual == 2)
                {
                    rigid.position = new Vector2(42.267f, -9.196464f);
                    camara.transform.position = new Vector3(28.6f, -9.2364f, -87.8f);
                }
            }


        }


        if (escena_actual >= 10 && escena_actual <= 15)
        {
            if (escena_actualest == escena_actual + 1)
            {
                if (escena_actual == 10)
                {

                    rigid.position = new Vector2(63.46f, 15.32f);
                    rect.position = new Vector3(52f, 14.87669f, -10f);

                }

                else if (escena_actual == 11)
                {
                    rigid.position = new Vector2(60.649f, 21.865f);
                    rect.position = new Vector3(52f, 22f, -10f);
                }
                else if (escena_actual == 12)
                {
                    rigid.position = new Vector2(234.64f, 15.2704f);
                    rect.position = new Vector3(223.6f, 15.27049f, -10f);
                }
                else if (escena_actual == 13)
                {
                    rigid.position = new Vector2(62.14f, -11.5f);
                    rect.position = new Vector3(62.22088f, -6.2f, -10f);

                }
                
        

            }

            
        }
        


    }





















    /*string escena_actual;

    void Awake() {

        string e = PlayerPrefs.GetString("Ultima Escena", null);

        if (e == null)
        {
            escena_actual = SceneManager.GetActiveScene().name;
        }
    }

    void Start () {
		
	}

    void Update() {
       
        PlayerPrefs.SetString("Ultima Escena", escena_actual);
        PlayerPrefs.Save();
        
	}*/
}
