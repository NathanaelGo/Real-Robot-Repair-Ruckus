using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public int winner = 0;
    public Sprite[] gallery; //store all your images in here at design time
    public Image displayImage; //The current image thats visible
    public Text[] winnerTxt;

    public Text followUpText;
    public string[] followUpStr;
    public int followUpLoc = 0;

    // Start is called before the first frame update
    void Start()
    {
        winner = PlayerPrefs.GetInt("Winner", 0);
        displayImage.sprite = gallery[winner];

        followUpText.text = followUpStr[0];

        if (winner == 1)
        {
            winnerTxt[1].text = "";
        }
        else if (winner == 2)
        {
            winnerTxt[0].text = "";
        }
        else
        {
            winnerTxt[1].text = "";
            winnerTxt[0].text = "";
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))      //Update the text on screen every time they press space
        {
            if (followUpStr.Length - 1 > followUpLoc)
            {
                followUpLoc++;
                followUpText.text = followUpStr[followUpLoc];
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void BtnToTitle()
    {
        SceneManager.LoadScene(0);
    }
}

