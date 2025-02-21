using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    public float turnSpeed; //the rate of horizontal movement
    public GameObject planePrefab;
    public int spawnTimer;  //counter to track interval until a new plane will spawn

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 turretPosition = transform.position;

        //Line 21-22 derived from Week 6 coding gym
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //gets value of mouse position and stores it in Vector3 variable
        mousePos.z = 0; //Makes the conversion from the direction Vector2 to mousePos Vector3 - transform work by rendering the Z value to be constant
        

        if (Input.GetKey("a")) //if the player moves their cursor to the right side of the screen
        {
            turretPosition.x += turnSpeed;   //moves the main camera to the right
        }

        if (Input.GetKey("d")) //if the player moves their cursor to the left side of the screen
        {
            turretPosition.x -= turnSpeed;   //moves the main camera to the left by making turn speed a negative
        }

        spawnTimer++;
        if(spawnTimer >= 250)   //when a certain amount of time passes, a new plane will be spawned
        {
            Instantiate(planePrefab);   //only creates an instance of the prefab as all movement and despawning is controlled by the plane or bullet
            spawnTimer = 0;
        }

        transform.position = turretPosition;    //updates the horizontal position
    }
}
