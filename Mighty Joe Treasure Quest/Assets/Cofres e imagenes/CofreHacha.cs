using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreHacha : MonoBehaviour {

    public Transform versuelo;
    public LayerMask capasuelo;
    public static Vector3 possuelo;
    Rigidbody2D rigid;
    bool ensuelo = false;

    void Awake () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {
        ensuelo = Physics2D.OverlapCircle(versuelo.position, 0.3f, capasuelo);
        if (rigid != null)
        {




            if (ensuelo)
            {
                Destroy(rigid);
                possuelo = transform.position;
            }
        }

    }

    public Vector3 getpossuelo() {
        Vector3 posicionsuelo = possuelo;
        return posicionsuelo;
    }
}
