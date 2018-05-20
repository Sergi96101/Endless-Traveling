using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

    public GeneradorPlataformes genP;
    public GeneradorBackground genB;

	public Player_Movement myPlayer;


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

		if (myPlayer.changeM == true) {
			if (genB.cas == GeneradorBackground.mapa.Prat)
			{
				myPlayer.bouncingActive = false;
				myPlayer.jetpackActive = false;
			}
			else if (genB.cas == GeneradorBackground.mapa.Planeta)
			{
				myPlayer.jetpackActive = false;
				myPlayer.bouncingActive = true;
			}
			else if (genB.cas == GeneradorBackground.mapa.Jetpack)
			{
				myPlayer.bouncingActive = false;
				myPlayer.jetpackActive = true;

			}
			myPlayer.changeM = false;
		}
	}
}
