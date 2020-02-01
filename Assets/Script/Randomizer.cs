using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class Randomizer : MonoBehaviour
{
    public GameObject blueBot;
    public GameObject redBot;
    public int test = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (test == 1)
        {
            test = 0;
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
