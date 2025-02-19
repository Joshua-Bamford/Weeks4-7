using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePosition : MonoBehaviour
{
    public float airSpeed;
    public int travelDirection;
    private SpriteRenderer planeRenderer;
    public int timeInAir;
    public int timeUntilDestroy;
    // Start is called before the first frame update
    void Start()
    {
        travelDirection = Random.Range(0, 2);   //randomly selects a 0 or 1 value (boolean expression)

        planeRenderer = GetComponent<SpriteRenderer>();
        if (travelDirection == 1 )
        {
            airSpeed = airSpeed * (-1); //the airspeed will be negative, meaning it will travel to the left if the travelDirection randomly selects 0
            planeRenderer.flipX = true; //the plane will be pointing to the left
        }

        Destroy(gameObject, timeUntilDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 planePosition = transform.position;
        planePosition.x += airSpeed;


        transform.position = planePosition;
        timeInAir++;

       // if (timeInAir == 500) {
       // 
       // }
    }
}
