using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GameMaster : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformStartPoint;

	public Player_Movement player;
	private Vector3 playerStartPoint;

	private DestructorElements[] platformList;

	// Use this for initialization
	void Start () {
		platformStartPoint = platformGenerator.position;
		playerStartPoint = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame()
	{
		StartCoroutine ("RestartGameC");
	}

	public IEnumerator RestartGameC(){
		player.gameObject.SetActive (false);
		yield return new WaitForSeconds(0.5f);
		platformList = FindObjectsOfType<DestructorElements>();
		for (int i = 0; i < platformList.Length; i++) {
			platformList [i].gameObject.SetActive (false);
		}
		player.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint; 
		player.gameObject.SetActive (true);
	}
}
