using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorBackground : MonoBehaviour {
    private float anchoFondo;
    private GameObject newFons;
    public Transform puntGeneracio;

    public ObjectPooler[] poolFons;
    public enum mapa {Prat, Planeta, Canvi};
    public mapa cas;

    private int contMapa;
    private int contCanvi;

    // Use this for initialization
    void Start () {
        anchoFondo = poolFons[1].pooledObject.GetComponent<SpriteRenderer>().size.x;
        cas = mapa.Prat;
        contMapa = 1;
        contCanvi = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < puntGeneracio.position.x)
        {
            if (contMapa == 30)
            {
                cas = mapa.Canvi;
            }
            switch (cas)
            {
                case mapa.Prat:
                    {
                        newFons = poolFons[0].GetPooledObject();
                        ++contMapa;
                        break;
                    }
                case mapa.Planeta:
                    {
                        newFons = poolFons[1].GetPooledObject();
                        ++contMapa;
                        break;
                    }
                case mapa.Canvi:
                    {
                        newFons = poolFons[2].GetPooledObject();
                        contMapa = 0;
                        ++contCanvi;
                        break;
                    }
            }

            if (contMapa == 0 && contCanvi == 3)
            {
                cas = (mapa)Random.Range(0, 2);
                contCanvi = 0;
            }

            transform.position = new Vector3(transform.position.x + anchoFondo / 2, transform.position.y, transform.position.z);

            newFons.transform.position = transform.position;
            newFons.transform.rotation = transform.rotation;
            newFons.SetActive(true);

            transform.position = new Vector3(transform.position.x + anchoFondo / 2, transform.position.y, transform.position.z);
        }
    }
}
