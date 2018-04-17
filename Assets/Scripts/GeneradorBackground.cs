﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorBackground : MonoBehaviour {
    private float anchoFondo;

    public GameObject newFons;
    public Transform puntGeneracio;

	// Use this for initialization
	void Start () {
        anchoFondo = GetComponent<SpriteRenderer>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < puntGeneracio.position.x)
        {
            transform.position = new Vector3(transform.position.x + anchoFondo / 2, transform.position.y, transform.position.z);

            newFons.transform.position = transform.position;
            newFons.transform.rotation = transform.rotation;

            transform.position = new Vector3(transform.position.x + anchoFondo / 2, transform.position.y, transform.position.z);
        }
    }
}
