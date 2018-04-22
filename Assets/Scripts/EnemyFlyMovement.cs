using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyMovement : MonoBehaviour {

    private PlayerMovement thePlayer;

    public float moveSpeed;

    public float PlayerRange;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerMovement>();
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed = Time.deltaTime);
		
	}
}
