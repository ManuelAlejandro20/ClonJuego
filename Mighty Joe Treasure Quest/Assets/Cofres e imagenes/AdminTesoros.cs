using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class AdminTesoros : MonoBehaviour {

    public RectTransform[] panelesinventario;

    GameObject jugador;
    VidaJoe scriptvida;

    public Database data;
    List<Item> listaitem;


    string[] lineas;

    static List<bool> abierto = new List<bool>();
    List<bool> abiertoaux = new List<bool>();
    public GameObject[] tesorosencontrados;
    public GameObject imagentesoro;
    static int[] inventario = new int[3] { -1, -1, -1 };

    static int numinvstatico;
    int numinv;

    CofrePrueba[] cp;

    bool max = true;

    void Awake() {
        Time.timeScale = 1;
        jugador = GameObject.FindGameObjectWithTag("Player");
        listaitem = data.items;
        scriptvida = jugador.GetComponent<VidaJoe>();
        cp = GetComponentsInChildren<CofrePrueba>(true);

        for(int i=0; i<listaitem.Capacity; i++) {
            
            abierto.Add(false);
        }

        abiertoaux = abierto;
    }

    void Update()
    {
        
        for (int i = 0; i < cp.Length; i++) {
            bool cofreabierto = cp[i].getabierto();
            if (cofreabierto && !abierto[i] && max) {
                int indice = listaitem.IndexOf(data.buscaritem(cp[i].gettesoro()));
                abierto[indice] = true;
                inventario[numinvstatico] = indice;
                numinvstatico++;
                if (numinvstatico == 3) {
                    max = false;
                }
            }

            cp[i].setbool(abierto[i]);
        }

        if (scriptvida.getvida1up() == 0) {
            max = false;
            eliminartesoros();
        }



        if (Input.GetKeyDown("space"))
        {
            if (Time.timeScale == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (inventario[i] != -1)
                    {
                        Destroy(tesorosencontrados[i]);
                    }
                }

            }

            if (Time.timeScale == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (inventario[i] != -1)
                    {
                        tesorosencontrados[i] = Instantiate(data.buscaritem(inventario[i]).imagen, panelesinventario[i].position, Quaternion.identity);
                        imagentesoro = GameObject.Find(listaitem[inventario[i]].nombre);
                        imagentesoro.GetComponent<RectTransform>().position = panelesinventario[i].position;
                    }

                }
            }
        }

        if (numinvstatico == 3) {

            if (transform.childCount > 0)
            {
                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }

      

    }

    

    public int getnuminv() {
        numinv = numinvstatico;
        return this.numinv;
    }

    public int valorfinal() {
        int valorfinal = 0;
        if (numinvstatico == 3) {
            for (int i = 0; i< 3; i++) {
                valorfinal += data.buscaritem(inventario[i]).valor;
            }
        }
        return valorfinal;
    }

    public void eliminartesoros() {

        for (int i=0; i<3; i++) {
            inventario[i] = -1;
        }

        abierto = abiertoaux;

        numinvstatico = 0;
       
        
    }

}
