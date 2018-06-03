using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPlataformes : MonoBehaviour {

    public enum mapa {Prat, Planeta, Jetpack, Canvi};
    const int numPlataformes = 4;
    public mapa cas;

    public Transform puntGeneracio;
    public float distanciaEntrePlataformesMin;
    public float distanciaEntrePlataformesMax;

    public ObjectPooler[] poolPlataformesPrat;
    public ObjectPooler[] poolPlataformesPlaneta;
    public ObjectPooler[] poolPlataformesCanvi;

    private GameObject newPlatform;
    
    private float[] anchurasPlataformas;
    private float distanciaEntrePlataformes;
    private int selectorPlataforma;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    public CoinGenerator myCoinGenerator;

    public float randomCoinTresh;

    private int contMapa;

    public float powerUpHeight;
    public ObjectPooler powerUpPool;
    public float powerUpTresh;   
     
    // Use this for initialization
    void Start () {
        anchurasPlataformas = new float[numPlataformes];

        for (int i = 0; i < numPlataformes; ++i)
        {
            anchurasPlataformas[i] = poolPlataformesPrat[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        myCoinGenerator = FindObjectOfType<CoinGenerator>();
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

            switch (cas) 
            {
                case mapa.Prat:
                {
                    newPlatform = poolPlataformesPrat[selectorPlataforma].GetPooledObject();
                    break;
                }
                case mapa.Planeta:
                {
                    newPlatform = poolPlataformesPlaneta[selectorPlataforma].GetPooledObject();
                    break;
                }
                case mapa.Jetpack:
                {
                    break;
                }
                case mapa.Canvi:
                {
                    newPlatform = poolPlataformesCanvi[selectorPlataforma].GetPooledObject();
                    break;
                }
            }

            if (Random.Range(0f, 100f) < powerUpTresh)
            {
                GameObject newPowerup = powerUpPool.GetPooledObject();
                newPowerup.transform.position = transform.position + new Vector3(distanciaEntrePlataformes / 2, Random.Range(powerUpHeight / 2, powerUpHeight), 0f);

                newPowerup.SetActive(true);
            }

            transform.position = new Vector3(transform.position.x + (anchurasPlataformas[selectorPlataforma] / 2) + distanciaEntrePlataformes, heightChange, transform.position.z);

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0f, 100f) < randomCoinTresh) {
                myCoinGenerator.GenerateCoins(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));
            }


            transform.position = new Vector3(transform.position.x + (anchurasPlataformas[selectorPlataforma] / 2), transform.position.y, transform.position.z);
        }
    }
}