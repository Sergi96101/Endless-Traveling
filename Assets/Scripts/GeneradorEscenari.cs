using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEscenari : MonoBehaviour {
    private float anchoFondo;
    private GameObject newFons;
    public Transform puntGeneracio;
    public GameObject triggerCanviSalt;
    public GameObject triggerIniciCanvi;

    public ObjectPooler[] poolFons;
    public enum mapa { Basic, Rebot, Jetpack, Canvi };
    public mapa cas;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
