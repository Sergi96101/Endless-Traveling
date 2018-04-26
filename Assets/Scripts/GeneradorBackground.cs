using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorBackground : MonoBehaviour {
    private float anchoFondo;
    public GameObject newFons;
    public Transform puntGeneracio;
    public GameObject triggerCanviSalt;
    public GameObject triggerIniciCanvi;

    public ObjectPooler[] poolFons;

    // Use this for initialization
    void Start () {
        anchoFondo = poolFons[0].pooledObject.GetComponent<SpriteRenderer>().size.x;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < puntGeneracio.position.x)
        {

            transform.position = new Vector3(transform.position.x + anchoFondo / 2, transform.position.y, transform.position.z);

            newFons.transform.position = transform.position;
            newFons.transform.rotation = transform.rotation;
            newFons.SetActive(true);

            transform.position = new Vector3(transform.position.x + anchoFondo / 2, transform.position.y, transform.position.z);
        }
    }
}
