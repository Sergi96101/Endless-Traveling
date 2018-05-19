using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {
    public bool doublePoints;
    public bool safeMode;

    public float duration;

    private ManagerPowerUps powerUpManager;
	// Use this for initialization
	void Start () {
        powerUpManager = FindObjectOfType<ManagerPowerUps>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.name == "player")
        {
            powerUpManager.setPowerUpActive(doublePoints, safeMode, duration);
        }
        gameObject.SetActive(false);
    }
}
