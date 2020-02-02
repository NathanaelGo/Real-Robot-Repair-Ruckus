using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class Randomizer : MonoBehaviour
{

    public GameObject blueBot;
    public GameObject redBot;

    [Header("Timer")]
    public bool EMPOn = true;
    public float timeBetweenEMP;
    private float timeHolderEMP;
    public GameObject timer;

    [Header("Debug Area")]
    public int test = 0;



    
    // Start is called before the first frame update
    void Start()
    {
        timeHolderEMP = Time.time;
    }

    // Update is called once per frame
    void Update()
    {   
        //For Debugging
        if (test == 1)
        {
            test = 0;
            randomizerControls();
        }

        if(test == 2)
        {
            Debug.Log(Time.time - timeBetweenEMP);
            Debug.Log(timeHolderEMP);
            test = 0;

        }

        if(test == 3)
        {
            for(int i = 0; i < 5; i++)
            {
                blueBot.GetComponent<BotControls>().setControlDesired(i);
                redBot.GetComponent<BotControls>().setControlDesired(i);
            }
        }

        if(EMPOn && (Time.time - timeBetweenEMP) >= timeHolderEMP)
        {
            timeHolderEMP = Time.time;
            Debug.Log("EMP FIRED");
            randomizerControls();
        }

    }

    public void randomizerControls()
    {
        System.Random random = new System.Random();

        List<string> controlHolder = new List<string>() { "e", "r", "t", "y", "u", "i", "o", "p", "[", "]", "f", "g", "h", "j", "k", "l", ";", "'","space", "z", "x", "c", "v", "b", "n", ",", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

        string[] blueControls = new string[5];
        string[] redControls = new string[5];

        int randomHolderVal = 0;

        for (int i = 0; i < 5; i++)
        {
            randomHolderVal = random.Next(0, controlHolder.Count);
            blueControls[i] = controlHolder[randomHolderVal];
            controlHolder.RemoveAt(randomHolderVal);

            
            randomHolderVal = random.Next(0, controlHolder.Count);
            redControls[i] = controlHolder[randomHolderVal];
            controlHolder.RemoveAt(randomHolderVal);
     
        }

        //Change controls here
        blueBot.GetComponent<BotControls>().updateControls(blueControls);
        redBot.GetComponent<BotControls>().updateControls(redControls);

    }
}
