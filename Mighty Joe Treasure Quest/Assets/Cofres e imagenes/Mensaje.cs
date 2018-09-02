using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mensaje : MonoBehaviour {

    //AudioSource auimagen;

    AudioSource au;
    AudioSource[] aunvl1;

    GameObject gomusica;

    int escena_actual;

    bool intro = false;
    bool cuerpo = false;

    void Awake() {
        //auimagen = GetComponent<AudioSource>();
        gomusica = GameObject.Find("Música");
        escena_actual = SceneManager.GetActiveScene().buildIndex;
        if (escena_actual >= 1 && escena_actual <= 3 || escena_actual <=7 && escena_actual >= 4)
        {
            aunvl1 = gomusica.GetComponents<AudioSource>();
            au = null;

        }
        else {
            
            au = gomusica.GetComponent<AudioSource>();
            aunvl1 = null;

        }

    }

    void Update() {
        if (Time.timeScale == 1) {
            Time.timeScale = 0;
            if (au == null)
            {
                obtener_musica();
            }
            else {
                au.Pause();

            }
        }

        if (Input.GetKeyDown("x")) {
            Time.timeScale = 1;
            if (au == null)
            {
                if (intro)
                {
                    aunvl1[0].UnPause();
                    intro = false;
                }
                else if (cuerpo)
                {
                    aunvl1[1].UnPause();
                    cuerpo = false;
                }
            }
            else {
                au.UnPause();

            }
            Destroy(gameObject);
        }




	}

    public void obtener_musica()
    {
        if (aunvl1[0].isPlaying)
        {
            intro = true;
            aunvl1[0].Pause();
        }
        else if (aunvl1[1].isPlaying)
        {
            cuerpo = true;
            aunvl1[1].Pause();
        }

    }
}
 