using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorBackground : MonoBehaviour {
    private float anchoFondo;
    private GameObject newFons;
    public Transform puntGeneracio;

    public ObjectPooler[] poolFons;
    private enum mapa { Prat, Planeta };
    private mapa cas;

    // Use this for initialization
    void Start () {
        anchoFondo = poolFons[1].pooledObject.GetComponent<SpriteRenderer>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < puntGeneracio.position.x)
        {

            cas = (mapa)Random.Range(0, 2);

            switch (cas)
            {
                case mapa.Prat:
                    {
                        newFons = poolFons[0].GetPooledObject();
                        break;
                    }
                case mapa.Planeta:
                    {
                        newFons = poolFons[1].GetPooledObject();
                        break;
                    }
            }

            transform.position = new Vector3(transform.position.x + anchoFondo / 2, transform.position.y, transform.position.z);

            newFons.transform.position = transform.position;
            newFons.transform.rotation = transform.rotation;
            newFons.SetActive(true);

            transform.position = new Vector3(transform.position.x + anchoFondo / 2, transform.position.y, transform.position.z);
        }
    }
}
