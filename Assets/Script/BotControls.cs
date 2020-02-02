﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotControls : MonoBehaviour
{
    [Header("Controls")]
    public string[] controls = new string[5];           //Controls used for player  |  Asigned in the Unity Editor
    public string[] desiredControls = new string[5];    //When a Cp is captured Controls used for player  |  Asigned in the Unity Editor
    public float maxSpeed = 2.0f;                       //Speed of the player


    [Header("Stuff used in Commands")]
    public Rigidbody2D botRB;                           //Rigidbody for position movement 
    public CommandPointManager cpm;
    public int playerNum = 0;
    public Vector2 robotSpawn;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //Movement & Animation Code

        if (Input.GetKey(controls[0])) //up
        {
            botRB.position += new Vector2 (0.0f, maxSpeed) * Time.deltaTime;
            anim.SetBool("isWalkLeft", false);
            anim.SetBool("isWalkRight", true);
        }
        if (Input.GetKey(controls[1])) //left
        {
            botRB.position += new Vector2(-maxSpeed, 0.0f) * Time.deltaTime;
            anim.SetBool("isWalkLeft", true);
            anim.SetBool("isWalkRight", false);
        }
        if (Input.GetKey(controls[2])) //right
        {
            botRB.position += new Vector2(maxSpeed, 0.0f) * Time.deltaTime;
            anim.SetBool("isWalkLeft", false);
            anim.SetBool("isWalkRight", true);
        }
        if (Input.GetKey(controls[3])) //down
        {
            botRB.position += new Vector2(0.0f, -maxSpeed) * Time.deltaTime;
            anim.SetBool("isWalkLeft", true);
            anim.SetBool("isWalkRight", false);
        }
        if (Input.GetKey(controls[4])) //interact
        {
            anim.SetBool("isWalkRight", false);
            anim.SetBool("isWalkLeft", false);
            interact();                                                                 
        }
        if (!Input.GetKey(controls[0]) && !Input.GetKey(controls[1]) && !Input.GetKey(controls[2]) && !Input.GetKey(controls[3]) && !Input.GetKey(controls[4]))
        {
            anim.SetBool("isWalkRight", false);
            anim.SetBool("isWalkLeft", false);
        }
    }

    public void interact()                                                              //Holder meathod for later use
    {
        Debug.Log("Interact Key Pressed");
    }


    public void updateControls(string[] newControls)                                    //Set controls
    {
        int[] cpState = cpm.cpState;
        for(int i = 0; i < 5; i++)
        {
            if (cpState[i] == playerNum)
            {
                controls[i] = desiredControls[i];
            }
            else
            {
                controls[i] = newControls[i];
            }
        }
    }

    public void setControlDesired(int cpNum)                                            //For setting controls when cp is captured
    {
        controls[cpNum] = desiredControls[cpNum];
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hazard")
        {
            moveRobotTo(robotSpawn);
        }

    }
    public void moveRobotTo(Vector2 location)
    {
        botRB.position = location;
    }

}
