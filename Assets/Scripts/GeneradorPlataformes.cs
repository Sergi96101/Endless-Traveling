using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPlataformes : MonoBehaviour {

    const int numPlataformes = 4;

    public Transform puntGeneracio;
    public float distanciaEntrePlataformesMin;
    public float distanciaEntrePlataformesMax;

    public ObjectPooler[] poolPlataformesBasic;

    public GameObject newPlatform;
    
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
            anchurasPlataformas[i] = poolPlataformesBasic[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {
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

        transform.position = new Vector3(transform.position.x + (anchurasPlataformas[selectorPlataforma] / 2) + distanciaEntrePlataformes, heightChange, transform.position.z);

        newPlatform.transform.position = transform.position;
        newPlatform.transform.rotation = transform.rotation;
        newPlatform.SetActive(true);

        transform.position = new Vector3(transform.position.x + (anchurasPlataformas[selectorPlataforma] / 2), transform.position.y, transform.position.z);
    }
}