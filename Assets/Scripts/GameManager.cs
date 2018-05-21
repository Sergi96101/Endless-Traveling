using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platStartPoint;

    public Transform backgroundGenerator;
    private Vector3 bgStartPoint;

    public Player_Movement myPlayer;
    private Vector3 playerStartPoint;

    private DestructorElements[] listPlatform;

    private ScoreController myStoreController;

    // Use this for initialization
    void Start() {
        platStartPoint = platformGenerator.position;
        playerStartPoint = myPlayer.transform.position;
        bgStartPoint = backgroundGenerator.position;

        myStoreController = FindObjectOfType<ScoreController>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void RestartGame()
    {
        StartCoroutine("RestartGame_CoRoutine");
    }

    public IEnumerator RestartGame_CoRoutine()
    {
        myStoreController.increaseScore = false;
        myPlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        listPlatform = FindObjectsOfType<DestructorElements>();
        for (int i = 0; i < listPlatform.Length; i++)
        {
            listPlatform[i].gameObject.SetActive(false);
        }

        myPlayer.transform.position = playerStartPoint;
        backgroundGenerator.position = bgStartPoint;
        platformGenerator.position = platStartPoint;
        myPlayer.gameObject.SetActive(true);
        myStoreController.increaseScore = true;
    } 
}
