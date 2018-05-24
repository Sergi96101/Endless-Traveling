﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCoins : MonoBehaviour {

    public int scoreUp;
    private ScoreController myScoreController;

	// Use this for initialization
	void Start () {
        myScoreController = FindObjectOfType<ScoreController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            myScoreController.CoinPicked(scoreUp);
            gameObject.SetActive(false);
        }
    }
}
