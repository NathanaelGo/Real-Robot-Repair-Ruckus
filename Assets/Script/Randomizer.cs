using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class Randomizer : MonoBehaviour
{

    public GameObject blueBot;
    public GameObject redBot;
    public GameObject randomizedText;
    public GameObject artilla;

    public AudioClip empBlast;

    private Animator artillaAnim;
    private AudioSource Sounds;

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
        artillaAnim = artilla.GetComponent<Animator>();
        Sounds = gameObject.GetComponent<AudioSource>();

        if(test == 5)
        {
            randomizerControls();
        }
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

        //Change Artilla animations

        if (EMPOn && (Time.time - (timeBetweenEMP * 0.75f)) >= timeHolderEMP)
        {
            artillaAnim.SetBool("isIdle", false);
            artillaAnim.SetBool("isStage1", false);
            artillaAnim.SetBool("isStage2", false);
            artillaAnim.SetBool("isStage3", true);
        }
        else if (EMPOn && (Time.time - (timeBetweenEMP * 0.5f)) >= timeHolderEMP)
        {
            artillaAnim.SetBool("isIdle", false);
            artillaAnim.SetBool("isStage1", false);
            artillaAnim.SetBool("isStage2", true);
            artillaAnim.SetBool("isStage3", false);
        }
        else if (EMPOn && (Time.time - (timeBetweenEMP * 0.25f)) >= timeHolderEMP)
        {
            artillaAnim.SetBool("isIdle", false);
            artillaAnim.SetBool("isStage1", true);
            artillaAnim.SetBool("isStage2", false);
            artillaAnim.SetBool("isStage3", false);
        }
        else
        {
            artillaAnim.SetBool("isIdle", true);
            artillaAnim.SetBool("isStage1", false);
            artillaAnim.SetBool("isStage2", false);
            artillaAnim.SetBool("isStage3", false);
        }

        //Fire EMP

        if (EMPOn && (Time.time - timeBetweenEMP) >= timeHolderEMP)
        {
            timeHolderEMP = Time.time;
            Sounds.PlayOneShot(empBlast, 1.0f);
            Debug.Log("EMP FIRED");
            randomizerControls();
        }

    }

    public void randomizerControls()
    {
        System.Random random = new System.Random();

        randomizedText.SetActive(true);

        //List<string> controlHolder = new List<string>() { "e", "r", "t", "y", "u", "i", "o", "p", "[", "]", "f", "g", "h", "j", "k", "l", ";", "'","space", "z", "x", "c", "v", "b", "n", ",", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0","-","\\","=" };
        //List<string> rcHolder = new List<string>() { "8", "9", "0", "-", "\\", "=","]","[","p","o","i","u","j","k","l",";","'",",",".","/"};    //Red possible inputs
        //List<string> bcHolder = new List<string>() {"1", "2", "3", "4", "5", "6", "7","e","r","t","y","f","g","h","z","x","c","v","b","n" };    //Blue possible inputs

        List<string> rcHolder = new List<string>() {"i","o","p","[","k","l",";","'",",",".","/" };
        List<string> bcHolder = new List<string>() { "1", "2", "3", "4", "5","e","r","f","c","x","z" };
        string[] blueControls = new string[5];
        string[] redControls = new string[5];

        int randomHolderVal = 0;

        for (int i = 0; i < 5; i++)
        {
            randomHolderVal = random.Next(0, bcHolder.Count);
            blueControls[i] = bcHolder[randomHolderVal];
            bcHolder.RemoveAt(randomHolderVal);

            
            randomHolderVal = random.Next(0, rcHolder.Count);
            redControls[i] = rcHolder[randomHolderVal];
            rcHolder.RemoveAt(randomHolderVal);
     
        }

        //Change controls here
        blueBot.GetComponent<BotControls>().updateControls(blueControls);
        redBot.GetComponent<BotControls>().updateControls(redControls);

    }


}
