using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscHaciaAdelante : MonoBehaviour {

	int escena;


	void Awake(){
		escena = SceneManager.GetActiveScene ().buildIndex;
		
	
	}


	void OnTriggerStay2D(Collider2D col)
	{

		if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.UpArrow))
		{
			SceneManager.LoadScene (escena + 1);
		}
	}


}
