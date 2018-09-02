using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cambioescenario21 : MonoBehaviour {

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
            SceneManager.LoadScene("Escenario 3 1er nivel", LoadSceneMode.Single);
        }
    }
}
