using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioEscenario2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	//El trigger detecta un game object el cual si tiene el tag player y se pulsa la tecla de la flecha hacia arriba
    //se utiliza la fuincion del scene management para cargar la siguiente escena
	}
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.UpArrow))
        {
            SceneManager.LoadScene("Escenario 2 1er nivel", LoadSceneMode.Single);
        }
    }
}
