using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPowerUps : MonoBehaviour {
    private bool doublePoints;
    private bool safeMode;

    private bool isActive;

    private float durationCounter;

    private ScoreController myScoreController;
    private GeneradorPlataformes myPlatformGenerator;

    private float pointsPerSecond;


    // Use this for initialization
    void Start () {
        myPlatformGenerator = FindObjectOfType<GeneradorPlataformes>();
        myScoreController = FindObjectOfType<ScoreController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            if (doublePoints)
            {
                myScoreController.doublePoints = true;
                myScoreController.countPoints = pointsPerSecond * 2f;
                
            }
            durationCounter -= Time.deltaTime;

            if (durationCounter <= 0)
            {
                myScoreController.countPoints = pointsPerSecond;
                myScoreController.doublePoints = false;
                isActive = false;
            }
        }
	}

    public void setPowerUpActive(bool points, bool safe, float time)
    {
        points = doublePoints;
        safe = safeMode;
        time = durationCounter;

        pointsPerSecond = myScoreController.countPoints;

        isActive = true;
    }
}
