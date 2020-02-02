using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPointManager : MonoBehaviour
{

    public int[] cpState = { 0, 0, 0, 0, 0 };       // 1 == Blue  | 2 == Red  |  0 == Unclaimed
    
    public int bluePoints = 0;
    public int redPoints = 0;
    public int pointsToWin = 150;

    public GameObject redScoreBar;

    public float lastPointAddTime;

    private int redTicks;
    private int blueTicks;

    // Start is called before the first frame update
    void Start()
    {
        lastPointAddTime = Time.time;
        redTicks = 0;
        blueTicks = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - 1 > lastPointAddTime)
        {
            lastPointAddTime = Time.time;
            addPoints();

            int hold = winner();
            if (hold == 1)
            {
                Debug.Log("Blue Wins!");
            }
            if (hold == 2)
            {
                Debug.Log("Red Wins!");
            }
            if(hold == 4)
            {
                Debug.Log("SUDDEN DEATH");
            }
        }
    }


    public void addPoints()
    {

        float redPercent = (((float)redPoints / (float)pointsToWin) * 100.0f);

        for (int i = 0; i < 5; i++)
        {
            if (cpState[i] == 1)
                bluePoints++;
            if (cpState[i] == 2)
                redPoints++;
            Debug.Log("Red Points: " + redPoints + " Red Ticks: " + redTicks + " Red Percentage: " + redPercent);
        }
        if(redPercent >= 4 * redTicks)
        {
            redTicks++;
            string newScoreBar = "Red_Bar/Red_Score_Bar_" + redTicks;
            Debug.Log("NewScoreBar:" + newScoreBar);
            redScoreBar.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(newScoreBar);
        }
    }

    public int winner()
    {
        if(bluePoints >= pointsToWin && redPoints >= pointsToWin)       //If both above points need to win
        {                                                               //Count up command points and the one who has the most wins if tied it goes to overtime
            int cpb = 0;
            int cpr = 0;
            for (int i = 0; i < 5; i++)
            {
                if (cpState[i] == 1)
                    cpb++;
                if (cpState[i] == 2)
                    cpr++;
            }

            if(cpb == cpr)
            {
                return 4;                                               //SUDDEN DEATH
            }
            if(cpb > cpr)
            {
                return 1;
            }
            return 2;
        }
        else if (bluePoints >= pointsToWin)                             //Blue wins
        {
            return 1;
        }
        else if (redPoints >= pointsToWin)                              //Red wins
        {
            return 2;
        }
        return 0;                                                       //Neither wins
    }

    void changeCapturePoint(int playerNumber)
    {
    
	}
}
