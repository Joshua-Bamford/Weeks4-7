using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    public float turnSpeed;
    public float scopeMagnification;
    GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 scopePosition = transform.position;

        //Line 21-22 derived from Week 6 coding gym
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //gets value of mouse position and stores it in Vector3 variable
        mousePos.z = 0; //Makes the conversion from the direction Vector2 to mousePos Vector3 - transform work by rendering the Z value to be constant
        

        if (mousePos.x >= 6) //if the player moves their cursor to the right side of the screen
        {
            scopePosition.x += turnSpeed;   //moves the main camera to the right
        }

        if (mousePos.x >= 6) //if the player moves their cursor to the left side of the screen
        {
            scopePosition.x -= turnSpeed;   //moves the main camera to the left by making turn speed a negative
        }

        transform.position = scopePosition;
    }
}
