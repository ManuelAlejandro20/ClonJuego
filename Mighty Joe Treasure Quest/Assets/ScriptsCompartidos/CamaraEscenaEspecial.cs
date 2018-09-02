using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraEscenaEspecial : MonoBehaviour {

	public Transform personaje;
	public float margen = 4f;
	Vector3 fase;
	public float maxX;
	public float minX;
	public float x;
    public float minY;
	public float maxY;
	public float y;
	void Start()
	{
		fase = transform.position - personaje.position;

	}

	public void FixedUpdate()
	{
		Vector3 posicionpersonaje = personaje.position + fase;
		transform.position = Vector3.Lerp(transform.position, posicionpersonaje, margen * Time.deltaTime);


		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp(pos.x, -minX, x * maxX);
		transform.position = pos;
		Vector3 posy = transform.position;
		posy.y = Mathf.Clamp(pos.y, y * -minY, maxY);
		transform.position = posy;
	}
}
