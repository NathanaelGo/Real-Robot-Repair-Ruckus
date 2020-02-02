using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public Transform wall;
    public Transform hazard;
    
    // Start is called before the first frame update
    void Start()
    {
        //Bottom right zig-zag wall
        Instantiate(wall, new Vector3(13.75f, -15.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(13.75f, -13, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(13.75f, -10.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(13.75f, -8, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(13.75f, -5.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(13.75f, -3, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(11.25f, -3, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(8.75f, -3, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(8.75f, -0.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(6.25f, -0.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(6.25f, 2, 0), Quaternion.identity);

        //Bottom right hazards
        Instantiate(hazard, new Vector3(18.875f, -10.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(16.25f, -5.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(21.25f, -5.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(18.875f, 5.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(21.25f, 5.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(21.25f, 3, 0), Quaternion.identity);

        //Top left zig-zag wall
        Instantiate(wall, new Vector3(-13.75f, 15.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-13.75f, 13, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-13.75f, 10.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-13.75f, 8, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-13.75f, 5.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-13.75f, 3, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-11.25f, 3, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-8.75f, 3, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-8.75f, 0.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-6.25f, 0.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-6.25f, -2, 0), Quaternion.identity);
        
        //Top left hazards
        Instantiate(hazard, new Vector3(-18.875f, 10.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(-16.25f, 5.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(-21.25f, 5.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(-18.875f, -5.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(-21.25f, -5.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(-21.25f, -3, 0), Quaternion.identity);


        //Blue spawn wall
        Instantiate(wall, new Vector3(-21.25f, -8, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-18.75f, -8, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-16.25f, -8, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-13.75f, -8, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-13.75f, -10.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-11.25f, -10.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-8.75f, -10.5f, 0), Quaternion.identity);

        //Blue spawn hazards
        Instantiate(hazard, new Vector3(-11.25f, -15.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(-8.75f, -15.5f, 0), Quaternion.identity);

        //Red spawn wall
        Instantiate(wall, new Vector3(21.25f, 8, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(18.75f, 8, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(16.25f, 8, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(13.75f, 8, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(13.75f, 10.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(11.25f, 10.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(8.75f, 10.5f, 0), Quaternion.identity);

        //Red spawn hazards
        Instantiate(hazard, new Vector3(11.25f, 15.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(8.75f, 15.5f, 0), Quaternion.identity);

        //Bottom L-wall
        Instantiate(wall, new Vector3(-1.25f, -10.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(1.25f, -10.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(3.75f, -10.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(3.75f, -13, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(3.75f, -15.5f, 0), Quaternion.identity);

        //Bottom hazards
        Instantiate(hazard, new Vector3(6.25f, -13, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(6.25f, -15.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(8.75f, -15.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(11.25f, -15.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(11.25f, -13, 0), Quaternion.identity);

        //Top L-wall
        Instantiate(wall, new Vector3(1.25f, 10.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-1.25f, 10.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-3.75f, 10.5f, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-3.75f, 13, 0), Quaternion.identity);
        Instantiate(wall, new Vector3(-3.75f, 15.5f, 0), Quaternion.identity);

        //Top hazards
        Instantiate(hazard, new Vector3(-6.25f, 13, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(-6.25f, 15.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(-8.75f, 15.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(-11.25f, 15.5f, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(-11.25f, 13, 0), Quaternion.identity);

        //Middle hazards
        Instantiate(hazard, new Vector3(0, 5, 0), Quaternion.identity);
        Instantiate(hazard, new Vector3(0, -5, 0), Quaternion.identity);

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
