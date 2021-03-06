﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPlataformes : MonoBehaviour {

    /*const int numPlataformes = 4;
    private mapa cas = mapa.prat;*/

    public GameObject[] plataformesGenerades;
    public Transform puntGeneracio;
    public float distanciaEntrePlataformesMin;
    public float distanciaEntrePlataformesMax;
    public ObjectPooler[] objectPoolPrat;
    public ObjectPooler[] objectPoolPlaneta;

    private GameObject newPlatform;
    private enum mapa {prat = 1, planeta = 2, jetpack = 3};

    private float[] anchurasPlataformas;
    private float distanciaEntrePlataformes;
    private int selectorPlataforma;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    // Use this for initialization
    void Start () {
        anchurasPlataformas = new float[numPlataformes];

        for (int i = 0; i < numPlataformes; ++i)
        {
            anchurasPlataformas[i] = objectPoolPrat[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < puntGeneracio.position.x)
        {
            distanciaEntrePlataformes = Random.Range(distanciaEntrePlataformesMin, distanciaEntrePlataformesMax);

            selectorPlataforma = Random.Range(0, 4);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            int j = (int)mapa.planeta;

            switch (cas) 
            {
                case mapa.prat: 
                {
                    GameObject newPlatform = objectPoolPrat[selectorPlataforma].GetPooledObject();
                    break;
                }
                case mapa.planeta:
                {
                    GameObject newPlatform = objectPoolPlaneta[selectorPlataforma].GetPooledObject();
                    break;
                }
            }

            transform.position = new Vector3(transform.position.x + (anchurasPlataformas[selectorPlataforma] / 2) + distanciaEntrePlataformes, heightChange, transform.position.z);

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            transform.position = new Vector3(transform.position.x + (anchurasPlataformas[selectorPlataforma] / 2), transform.position.y, transform.position.z);
        }
    }
}