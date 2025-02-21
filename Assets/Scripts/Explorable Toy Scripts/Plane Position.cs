using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlanePosition : MonoBehaviour
{
    public float airSpeed;
    public int travelDirection; //either 0 or 1. Acts mostly like a boolean expression
    private SpriteRenderer planeRenderer;   //reference to plane's renderer required to flip the sprite based on the direction of travel
    public int timeInAir; 
    public int timeUntilDestroy;    //counter for the time until the prefab automatically destroys itself when not fired upon
    public Vector2 planePosition;
    public bool planeHit;   //bool value set to true by bullet script if hit has been detected
    // Start is called before the first frame update
    void Start()
    {
        planePosition = new Vector2 (Random.Range(-10f, 10f), Random.Range(6f, 0f));    //spawns at a random position within bounds of camera 
        transform.position = planePosition;

        travelDirection = Random.Range(0, 2);   //randomly selects a 0 or 1 value (boolean expression)
        planeHit = false;   //starts false as the plane hasn't been hit yet
        planeRenderer = GetComponent<SpriteRenderer>(); //gets a reference to the plane sprite so that it can be flipped to match the direction if neccesary
        if (travelDirection == 1 )  //the plane sprite faces right by default, so it must only need to be flipped when the travel direction is negative
        {
            airSpeed = airSpeed * (-1); //the airspeed will be negative, meaning it will travel to the left if the travelDirection randomly selects 0
            planeRenderer.flipX = true; //the plane will be pointing to the left
        }

        Destroy(gameObject, timeUntilDestroy);  //removes plane instance from scene after a period of time without being hit
    }

    // Update is called once per frame
    void Update()
    {
        planePosition = transform.position; //sets the game object's position to a Vector2 which cam be used to update it according to the speed
        planePosition.x += airSpeed;    //incremets plane position according to speed variable


        transform.position = planePosition; //updates object position to new value
        timeInAir++;

        if (planeHit == true) { //destroy plane object when it has been hit by bullet
            Destroy(gameObject);
            Debug.Log("Plane Destroyed");
        }
    }
}
