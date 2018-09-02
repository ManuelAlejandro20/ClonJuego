using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 public class Inventario : MonoBehaviour
 {
		
    Canvas canvas;
	AudioSource au;

	bool pausa;
	bool despausa;

	public AudioClip[] efectos;
    
	void Awake(){

		au = GetComponent<AudioSource> ();
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    /*La imagen del inventario inicia desactivada*/
    void Start()
    {
        
    }

    
    /*Cuando se aprete pausa la imagen del inventario va a aparecer o desaparecer dependiendo de las condiciones*/
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            if (Time.timeScale == 1)
            {
                canvas.enabled = true;
				pausa = true;
                Time.timeScale = 0;
            }
            else if (Time.timeScale == 0)
            {
                canvas.enabled = false;
				despausa = true;
                Time.timeScale = 1;
            }
        }

		if (canvas.enabled && pausa) {
			au.clip = efectos [0];
			au.Play ();
			pausa = false;

		
		}

		if(!canvas.enabled && despausa){
			au.clip = efectos [1];
			au.Play ();
			despausa = false;
            
		}

    
    }

    public bool estadopau() {
        return this.pausa;
    }

    public bool estadodespau() {
        return this.despausa;
    }
 }