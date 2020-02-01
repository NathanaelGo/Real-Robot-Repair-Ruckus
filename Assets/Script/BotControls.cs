using System.Collections;
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

}
