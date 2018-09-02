using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioEscenario2F : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerStay2D(Collider2D other)
	{

		if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.UpArrow))
		{
			SceneManager.LoadScene("escena 2 nivel final", LoadSceneMode.Single);
		}
	}
}
