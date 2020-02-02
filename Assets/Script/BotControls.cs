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

    [Header("Sprites")]
    public Sprite interactSprite;
    public Sprite upSprite;
    public Sprite leftSprite;
    public Sprite downSprite;
    public Sprite rightSprite;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //Movement Code

        if (Input.GetKey(controls[0]))
        {
            botRB.position += new Vector2 (0.0f, maxSpeed) * Time.deltaTime;
        }
        if (Input.GetKey(controls[1]))
        {
            botRB.position += new Vector2(-maxSpeed, 0.0f) * Time.deltaTime;
        }
        if (Input.GetKey(controls[2]))
        {
            botRB.position += new Vector2(maxSpeed, 0.0f) * Time.deltaTime;
        }
        if (Input.GetKey(controls[3]))
        {
            botRB.position += new Vector2(0.0f, -maxSpeed) * Time.deltaTime;
        }
        if (Input.GetKey(controls[4]))
        {
            interact();                                                                 
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

        if (collision.tag == "Interact CP")
        {
              collision.gameObject.GetComponent<SpriteRenderer>().sprite = interactSprite;
		}

        if (collision.tag == "Up CP")
        {
              collision.gameObject.GetComponent<SpriteRenderer>().sprite = upSprite;
		}

        if (collision.tag == "Left CP")
        {
              collision.gameObject.GetComponent<SpriteRenderer>().sprite = leftSprite;
		}

        if (collision.tag == "Down CP")
        {
              collision.gameObject.GetComponent<SpriteRenderer>().sprite = downSprite;
		}

        if (collision.tag == "Right CP")
        {
              collision.gameObject.GetComponent<SpriteRenderer>().sprite = rightSprite;
		}

    }
    public void moveRobotTo(Vector2 location)
    {
        botRB.position = location;
    }

}
