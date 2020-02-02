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
    public Vector2 robotSpawn;
    public GameObject spawnPoint;
    private Animator anim;
    public GameObject deathExplosion;
    private bool canMove;
    public float interactOffset;

    [Header("Sprites")]
    public Sprite interactSprite;
    public Sprite upSprite;
    public Sprite leftSprite;
    public Sprite downSprite;
    public Sprite rightSprite;

    [Header("Sounds")]
    public AudioClip walk;
    public AudioClip explosion;

    private AudioSource Sound;


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        robotSpawn = new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y + 1.0f);
        canMove = true;
        Sound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canMove)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime + interactOffset >= anim.GetCurrentAnimatorStateInfo(0).length)
            {
                canMove = true;
                anim.SetBool("isInteract", false);
            }
        }
        //Movement & Animation Code
        if (canMove)
        {
            if (Input.GetKey(controls[0])) //up
            {
                botRB.position += new Vector2(0.0f, maxSpeed) * Time.deltaTime;
                anim.SetBool("isWalkLeft", false);
                anim.SetBool("isWalkRight", true);
                if (!Sound.isPlaying)
                {
                    Sound.PlayOneShot(walk, 1.0f);
                }                
            }
            if (Input.GetKey(controls[1])) //left
            {
                botRB.position += new Vector2(-maxSpeed, 0.0f) * Time.deltaTime;
                anim.SetBool("isWalkLeft", true);
                anim.SetBool("isWalkRight", false);
                if (!Sound.isPlaying)
                {
                    Sound.PlayOneShot(walk, 1.0f);
                }
            }
            if (Input.GetKey(controls[2])) //right
            {
                botRB.position += new Vector2(maxSpeed, 0.0f) * Time.deltaTime;
                anim.SetBool("isWalkLeft", false);
                anim.SetBool("isWalkRight", true);
                if (!Sound.isPlaying)
                {
                    Sound.PlayOneShot(walk, 1.0f);
                }
            }
            if (Input.GetKey(controls[3])) //down
            {
                botRB.position += new Vector2(0.0f, -maxSpeed) * Time.deltaTime;
                anim.SetBool("isWalkLeft", true);
                anim.SetBool("isWalkRight", false);
                if (!Sound.isPlaying)
                {
                    Sound.PlayOneShot(walk, 1.0f);
                }
            }
            if (Input.GetKey(controls[4])) //interact
            {
                anim.SetBool("isWalkRight", false);
                anim.SetBool("isWalkLeft", false);
                anim.SetBool("isInteract", true);
                canMove = false;
            }
            if (!Input.GetKey(controls[0]) && !Input.GetKey(controls[1]) && !Input.GetKey(controls[2]) && !Input.GetKey(controls[3]) && !Input.GetKey(controls[4]))
            {
                anim.SetBool("isWalkRight", false);
                anim.SetBool("isWalkLeft", false);
            }
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


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Hazard")
        {
            moveRobotTo(robotSpawn);
        }

        if (collision.tag == "Interact CP" && Input.GetKey(controls[4]))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = interactSprite;
            cpm.cpState[4] = playerNum;
            setControlDesired(4);
        }

        if (collision.tag == "Up CP" && Input.GetKey(controls[4]))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = upSprite;
            cpm.cpState[0] = playerNum;
            setControlDesired(0);
        }

        if (collision.tag == "Left CP" && Input.GetKey(controls[4]))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = leftSprite;
            cpm.cpState[1] = playerNum;
            setControlDesired(1);
        }

        if (collision.tag == "Down CP" && Input.GetKey(controls[4]))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = downSprite;
            cpm.cpState[3] = playerNum;
            setControlDesired(3);
        }

        if (collision.tag == "Right CP" && Input.GetKey(controls[4]))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = rightSprite;
            cpm.cpState[2] = playerNum;
            setControlDesired(2);
        }

    }
    public void moveRobotTo(Vector2 location)
    {
        Instantiate(deathExplosion, gameObject.transform.position, Quaternion.identity);
        Sound.PlayOneShot(explosion, 1.0f);
        botRB.position = location;
        anim.SetBool("isWalkRight", false);
        anim.SetBool("isWalkLeft", false);
        anim.SetBool("isInteract", true);
        canMove = false;
    }

}
