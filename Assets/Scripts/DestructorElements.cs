using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorElements : MonoBehaviour {

    private GameObject puntDestruccio;

	// Use this for initialization
	void Start () {
        puntDestruccio = GameObject.Find("PuntDestruccioElements");
	}
	
	// Update is called once per frame
	void Update () {
	    if (transform.position.x < puntDestruccio.transform.position.x)
        {
            gameObject.SetActive(false);
        }	
	}
}
