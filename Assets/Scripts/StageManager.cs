using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

    public GeneradorPlataformes genP;
    public GeneradorBackground genB;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (genB.cas == GeneradorBackground.mapa.Prat)
        {
            genP.cas = GeneradorPlataformes.mapa.Prat;
        }
        else if (genB.cas == GeneradorBackground.mapa.Planeta)
        {
            genP.cas = GeneradorPlataformes.mapa.Planeta;
        }
        else if (genB.cas == GeneradorBackground.mapa.Jetpack)
        {
            genP.cas = GeneradorPlataformes.mapa.Jetpack;
        }
        else
        {
            genP.gameObject.SetActive(true);
            genP.cas = GeneradorPlataformes.mapa.Canvi;
        }
	}
}
