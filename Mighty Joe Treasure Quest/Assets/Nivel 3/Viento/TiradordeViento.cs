using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiradordeViento : MonoBehaviour {

    float[] vel = new float[6] { 40f, 45f, 50f, 55f, 60f, 65f };

    public GameObject vientoprefab;

    public GameObject arribaizquierda;
    public GameObject abajoizquierda;
    public GameObject arribaderecha;
    public GameObject abajoderecha;

    GameObject clon;

    bool abajobool;
    bool arribabool;
    bool moverse = false;

    RectTransform recttran;
    RectTransform recttranarribader;
    RectTransform recttranabajoder;
    RectTransform recttranarribaiz;
    RectTransform recttranabajoiz;

    float tiempos;
    int direccionviento;
	AudioSource au;

    Viento scriptviento;

    void Awake() {

		au = GetComponent<AudioSource> ();
        recttran = GetComponent<RectTransform>();
        recttranarribader = arribaderecha.GetComponent<RectTransform>();
        recttranabajoder = abajoderecha.GetComponent<RectTransform>();
        recttranarribaiz = arribaizquierda.GetComponent<RectTransform>();
        recttranabajoiz = abajoizquierda.GetComponent<RectTransform>();
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        scriptviento = jugador.GetComponent<Viento>();

    }
	void Start () {

    }
	
	void Update () {


        tiempos += Time.deltaTime;
        direccionviento = scriptviento.getdireccionviento();

        if (!moverse) {

            posicion();

        }
        

        if (direccionviento == 2)
        {
            if (arribabool)
            {

                recttran.position = Vector3.MoveTowards(recttran.position, recttranarribader.position, 0.3f);
                if (recttran.position == recttranarribader.position)
                {
                    abajobool = true;
                    arribabool = false;

                }
            }

            else if (abajobool)
            {


                recttran.position = Vector3.MoveTowards(recttran.position, recttranabajoder.position, 0.3f);
                if (recttran.position == recttranabajoder.position)
                {
                    abajobool = false;
                    arribabool = true;

                }
            }
        }
        else if(direccionviento == 1)
        {
            if (arribabool)
            {

                recttran.position = Vector3.MoveTowards(recttran.position, recttranarribaiz.position, 0.3f);
                if (recttran.position == recttranarribaiz.position)
                {
                    abajobool = true;
                    arribabool = false;

                }
            }

            else if (abajobool)
            {


                recttran.position = Vector3.MoveTowards(recttran.position, recttranabajoiz.position, 0.3f);
                if (recttran.position == recttranabajoiz.position)
                {
                    abajobool = false;
                    arribabool = true;

                }
            }

        }

        if (direccionviento == 0) {
            moverse = false;
        }
        


    }

    void funcionviento()
    {

        GameObject[] vientos = GameObject.FindGameObjectsWithTag("Viento");
        int cuenta = vientos.Length;
       
        if (tiempos>=0.2f && cuenta < 6 && direccionviento!=0)
        {
            int num = Random.Range(0, 5);
			if (!au.isPlaying) {
				
				au.Play ();

			}


            clon = Instantiate(vientoprefab, new Vector3(transform.position.x, transform.position.y, -9f), Quaternion.identity) as GameObject;
            if (direccionviento == 2)
            {
                
                clon.GetComponent<Rigidbody2D>().velocity = new Vector2(-vel[num], GetComponent<Rigidbody2D>().velocity.y);
               
            }

            else if(direccionviento == 1)
            {


                clon.GetComponent<Rigidbody2D>().velocity = new Vector2(vel[num], GetComponent<Rigidbody2D>().velocity.y);


            }
            Destroy(clon, 1f);
            tiempos = 0;
        }

    }

    void posicion() {
        string nombre = this.name;

        if (nombre.Equals("Lanzaviento arriba"))
        {
            if (direccionviento == 2)
            {
                recttran.position = recttranarribader.position;
            }
            else if (direccionviento == 1)
            {
                recttran.position = recttranarribaiz.position;
            }
            abajobool = true;
            arribabool = false;
        }
        else
        {

            if (direccionviento == 2)
            {
                recttran.position = recttranabajoder.position;
            }
            else if (direccionviento == 1)
            {
                recttran.position = recttranabajoiz.position;
            }
            abajobool = false;
            arribabool = true;

        }

        moverse = true;
       

    }

}
