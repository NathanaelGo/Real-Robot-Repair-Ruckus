using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{
    public Sprite[] gallery; //store all your images in here at design time
    public Image displayImage; //The current image thats visible
    public int currentInstruction = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayImage.sprite = gallery[currentInstruction];
    }

    public void btnNextInstruction()
    {
        if(gallery.Length-1>currentInstruction)
            currentInstruction++;
    }

    public void btnPrevInstruction()
    {
        if (0 < currentInstruction)
            currentInstruction--;
    }

    public void toTitleBtn()
    {
        SceneManager.LoadScene(0);
    }

    public void playGameBtn()
    {
        SceneManager.LoadScene(2);
    }

}
