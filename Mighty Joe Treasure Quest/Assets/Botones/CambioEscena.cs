using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour {

    /*Este Script esta asociado a la escena de pantalla de titulo y lleva hacia la primera escena del juego o directamente se
     sale de este*/
	void Update () {
		
	}

    public void primerescenario()
    {

        SceneManager.LoadScene(1);
    }

    public void Salirdejuego()
    {
        Application.Quit();

    }


}

