﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public bool bouncingActive;
    public bool jetpackActive;
	public bool boundActive;
    //velocitat i força de salt del pers.
    public float speed;
    public float force;
    public float jetpackForce = 75.0f;
    //variables per a determinar el temps de salt del personatge i mantindre clic
    public float jumpTime;
    private float jumpTimeCount;
    //variables per augmentar la velocitat del player segons distancia
    public float speedIncrease;
    public float speedDist;
    private float speedDistCount;

    //boolea per tocar terra
    public bool Isground;
    public LayerMask WhichGround;//escollir el layer amb el que colisiona
    public Transform checkGround;
    public float sizeDetection;
    //escollir l'objecte amb el que colisiona
    //public Collider2D myColl;
    private Rigidbody2D myRigid;

    private Animator myAnim;

    // Use this for initialization
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        //myColl = GetComponent<Collider2D>();
        jumpTimeCount = jumpTime;

        myAnim = GetComponent<Animator>();

        speedDistCount = speedIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > speedDistCount)
        {
            speedDistCount += speedDist;
            speedDist = speedDist * speedIncrease;
            speed = speed + speedIncrease;
        };
        //velocitat en x i y noves
        //corre cap a la dreta sol
        myRigid.velocity = new Vector2(speed, myRigid.velocity.y);
    }

    private void FixedUpdate()
    {
        //MECANICA SALT MAPA 1
        //boolea ground = quan toca el layer que hem escollit
        
        if (Input.GetButtonDown("Fire1"))
        {
            jetpackActive = !jetpackActive;
            bouncingActive = false;
        }
        if (Input.GetButtonDown("Fire3"))
        {
            bouncingActive = !bouncingActive;
            jetpackActive = false;
        }


        Isground = Physics2D.OverlapCircle(checkGround.position, sizeDetection, WhichGround);

        if (!jetpackActive)
        {
            //salt
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                //detctar si toca terra per no fer salts infinits
                if (Isground)
                {
                    myRigid.velocity = new Vector2(myRigid.velocity.x, force);
                    jumpTimeCount = jumpTime;
                }
            }
            if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)))
            {
                //detctar si toca terra per no fer salts infinits
                if (jumpTimeCount > 0 && !Isground)
                {
                    myRigid.velocity = new Vector2(myRigid.velocity.x, force);
                    jumpTimeCount -= Time.deltaTime;
                }
            }
            if ((Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)))
            {
                jumpTimeCount = 0;
            }
        }
        //MECANICA SALT MAPA 2
        else if (jetpackActive)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {

                myRigid.velocity = new Vector2(myRigid.velocity.x, jetpackForce);

            }
        }
        else if (bouncingActive)
        {
			if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)))
			{
				//detctar si toca terra per no fer salts infinits
				if (jumpTimeCount > 0 && !Isground)
				{
					myRigid.velocity = new Vector2(myRigid.velocity.x, force);
					jumpTimeCount -= Time.deltaTime;
				}
			}
			if ((Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)))
			{
				jumpTimeCount = 0;
			}
            //planejar 
            //salt llarg
        }

        /* if (Input.GetMouseButtonDown(0))
             Debug.Log("click");*/

        myAnim.SetFloat("Speed", myRigid.velocity.x);
        myAnim.SetBool("Is_Ground", Isground);
    }

}