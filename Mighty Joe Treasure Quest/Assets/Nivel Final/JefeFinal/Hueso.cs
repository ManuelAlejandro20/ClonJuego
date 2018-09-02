using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hueso : MonoBehaviour {

    [SerializeField] bool ensuelo;
    [SerializeField] Transform Circulo;
    [SerializeField] LayerMask capasuelo;
    [SerializeField] float vibracion;

    float tiempocamara = 0.8f;
    RectTransform rect;
    AudioSource au;

	void Awake () {
        au = GetComponent<AudioSource>();
        GameObject camara = GameObject.Find("Main Camera");
        rect = camara.GetComponent<RectTransform>();
    }
	
	void FixedUpdate () {

        ensuelo = Physics2D.OverlapCircle(Circulo.position, 1.5f, capasuelo);
        if (ensuelo) {
            camaratiembla();
        }

    }

    void camaratiembla() {

        if (!au.isPlaying)
        {
            au.Play();
        }
        Vector3 posini = rect.position;
        
        if (tiempocamara > 0f)
        {
            
            Vector2 vector = Random.insideUnitSphere * vibracion;
            rect.position = new Vector3(rect.position.x + vector.x, rect.position.y + vector.y, -10f);
            tiempocamara -= Time.fixedDeltaTime;
        }
        else
        {
            rect.position = posini;
            tiempocamara = 0.8f;
        }
    }
}
