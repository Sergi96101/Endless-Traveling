using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	public float scoreCount;
	public float highScoreCount;

	public float countPoints;

    public bool increaseScore;

    public bool doublePoints;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (increaseScore)
        {
            scoreCount += countPoints * Time.deltaTime;
        }
		if (scoreCount > highScoreCount) {
			highScoreCount = scoreCount;
		}

        scoreText.text = "Score: " + (int)scoreCount;
		highScoreText.text = "High Score : " + (int)highScoreCount; 

	}

}
