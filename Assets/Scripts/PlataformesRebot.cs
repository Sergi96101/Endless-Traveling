using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformesRebot : MonoBehaviour {

    int rebot;

	// Use this for initialization
	void Start () {
        rebot = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "player")
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(other.gameObject.GetComponent<Rigidbody2D>().velocity.x, rebot);
        }
    }
}
