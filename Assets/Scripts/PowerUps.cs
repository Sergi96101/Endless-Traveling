using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {
    public bool doublePoints;
    public bool slowMode;

    public float duration;

    public Sprite[] powerUpSprite;

    private ManagerPowerUps powerUpManager;
	// Use this for initialization
	void Start () {
        powerUpManager = FindObjectOfType<ManagerPowerUps>();
	}

    void SetPowerUp()
    {
        int selectPowerUp = Random.Range(0,2);

        switch (selectPowerUp)
        {
            case 0:  doublePoints = true; break;
            case 1:  slowMode = true; break;
        }
        GetComponent<SpriteRenderer>().sprite = powerUpSprite[selectPowerUp];
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.name == "Player")
        {
            powerUpManager.setPowerUpActive(doublePoints, slowMode, duration);
            Debug.Log("Touch");
        }
        gameObject.SetActive(false);
    }
}
