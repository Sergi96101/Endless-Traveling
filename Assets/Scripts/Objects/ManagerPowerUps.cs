using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPowerUps : MonoBehaviour {
    private bool doublePoints;
    private bool slowMode;

    private bool isActive;

    private float durationCounter;

    private Player_Movement myPlayer;

    private ScoreController myScoreController;
    private GeneradorPlataformes myPlatformGenerator;

    private float normalPointsPerSec;
    private float normalSpeed;

    // Use this for initialization
    void Start () {
        myPlatformGenerator = FindObjectOfType<GeneradorPlataformes>();
        myScoreController = FindObjectOfType<ScoreController>();
        myPlayer = FindObjectOfType<Player_Movement>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            durationCounter -= Time.deltaTime;

            if (doublePoints)
            {
                myScoreController.doublePoints = true;
                myScoreController.countPoints = normalPointsPerSec * 2;
                
            }

            else if (slowMode)
            {
                myPlayer.speed = normalSpeed - 0.75f;
            }
            if (durationCounter <= 0)
            {
                myScoreController.countPoints = normalPointsPerSec;
                myScoreController.doublePoints = false;
                myPlayer.speed = normalSpeed;
                isActive = false;
            }
        }
	}

    public void setPowerUpActive(bool points, bool slow, float time)
    {
        doublePoints = points;
        slowMode = slow;
        durationCounter = time;

        normalPointsPerSec = myScoreController.countPoints;
        normalSpeed = myPlayer.speed;

        isActive = true;
    }
}
