using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public AnimationCurve bulletCurve;
    [Range(0, 1)] public float t;
    public float bulletVelocity;    //pretty self explanatory. The amount that the bullet position transforms every frame when fired
    public Vector2 bulletSpawn;     //constant value at bottom centre of the camera
    public Vector3 bulletDisperse;  //the furthest point from the spawner that the bullet object can travel. Is always the current mouse position
    public GameObject planePrefab;  //must grab a reference to the plane prefab for hit detection
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Line 24-26 derived from Week 6 coding gym
        bulletDisperse = Camera.main.ScreenToWorldPoint(Input.mousePosition); //the point at which the bullet reaches its lowest scale and furthest position from spawn is at the crosshairs
        bulletDisperse.z = 0;   //the Z has to be zeroed to allow the Vector3 to be used like a Vector2. THis is only neccessary for the direction set
        Vector2 direction = bulletDisperse - transform.position;    //the bullet will always have its up value (green transform axis) pointed to the crosshair
        transform.up = direction;
        
        t += bulletVelocity;    //update current position in animation curve


        transform.position = Vector2.Lerp(bulletSpawn, bulletDisperse, t);  //updates the bullet position according to the location in between the start and end position of the bullet's path and interpolates based on curve

        Vector2 bulletDistance = transform.localScale;  //bulletDistance is the modifiable value use to change the object scale. 
        bulletDistance.x = Mathf.Lerp(1, 0, t); //uses same animation curve and linear interpolation as the position, but the size scales from it's native scale to no size at all
        bulletDistance.y = Mathf.Lerp(1, 0, t);

        Vector2 planeHitbox = planePrefab.transform.position;   //sets the plane prefab's position to a Vector2 which can be used in this script to check the bullet's position in relation to it
        

        if(bulletDistance.x <= 0f)
        {
            if(planeHitbox.x <= (bulletDisperse.x + 5) && planeHitbox.x >= (bulletDisperse.x - 5) && planeHitbox.y <= (bulletDisperse.y + 5) && planeHitbox.y >= (bulletDisperse.y - 5))
            {   //the area in which a hit will be registered is 5 units around the centre of the plane
                PlanePosition plane = planePrefab.GetComponent<PlanePosition>();    //reference to the plane prefab's script
                plane.planeHit = true;  //sends value to plane position script which will prompt it to destroy itself
                Debug.Log("Plane Hit");
                Destroy(gameObject);    //bullet is always destroyed after it reaches its maximum range

            }

            else  //in the case of a miss
            {
             Destroy(gameObject); //bullet is always destroyed after it reaches its maximum range
            }
        }

       transform.localScale = bulletDistance;

    }
}
