using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofrePrueba : MonoBehaviour {

    public GameObject prefabbrillo;
    public string tesoro;
    public Database data;
    Animator anim;
    Animation anim2;
    GameObject destelloclon;
    AudioSource au;
    GameObject admintesoros;
    AdminTesoros at;

    GameObject mensaje;

    public bool abierto;
    bool destello = false;
    bool sonido;

	void Awake () {
        anim = GetComponent<Animator>();
        au = GetComponent<AudioSource>();
        admintesoros = GameObject.Find("AdminTesoros");
        at = admintesoros.GetComponent<AdminTesoros>();

    }
	
	
	void Update () {
        if (abierto && mensaje != null) {
            
            if (destelloclon == null && at.getnuminv() < 2)
            {
                destelloclon = Instantiate(prefabbrillo, transform.position, Quaternion.identity) as GameObject;
            }
            destello = true;
            
            
        }

        if (destello && Time.timeScale == 1 && mensaje == null) {
            destellosube();

        }
        anim.SetBool("Abierto", abierto);
	}


    void destellosube() {
      
        if (destelloclon != null) {

    
            destelloclon.transform.position = new Vector3(destelloclon.transform.position.x, destelloclon.transform.position.y + 0.3f, destelloclon.transform.position.z);
           
            Destroy(destelloclon, 0.3f);
            if (!sonido)
            {
                au.Play();
                sonido = true;
            }
            if (destelloclon == null) {
                destello = false;
            }
            
               
            
        }

    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" && Input.GetKeyDown(KeyCode.UpArrow) && !abierto)
        {
            GameObject jugador = col.gameObject;
            VidaJoe scriptvida = jugador.GetComponent<VidaJoe>();
            if (this.gameObject.name == "Cofre Hacha") {
                scriptvida.setvida(100f);
            }

            else if (scriptvida.getvida() >= 70f)
            {
                scriptvida.setvida(100f);
            }
            else
            {
                scriptvida.setvida(scriptvida.getvida() + 30f);
            }
            anim.SetBool("Abierto", true);
            abierto = true;
            mensaje = Instantiate(data.buscaritem(gettesoro()).mensaje, transform.position, Quaternion.identity);
            
        }
    }

    public string gettesoro() {
        return this.tesoro;
    }

    public bool getabierto() {
        return this.abierto;
    }

    public void setbool(bool nuevoestadocofre) {
        this.abierto = nuevoestadocofre;
    }
}
