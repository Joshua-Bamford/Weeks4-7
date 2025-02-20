using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public AnimationCurve bulletCurve;
    [Range(0, 1)] public float t;
    public float bulletVelocity;
    public SpriteRenderer roundType;
    public Vector2 bulletSpawn;
    public Vector3 bulletDisperse;
    public GameObject planePrefab;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Line 21-22 derived from Week 6 coding gym
        bulletDisperse = Camera.main.ScreenToWorldPoint(Input.mousePosition); //the point at which the bullet reaches its lowest scale and furthest position from spawn is at the crosshairs
        bulletDisperse.z = 0;
        Vector2 direction = bulletDisperse - transform.position;
        transform.up = direction;
        
        t += bulletVelocity;


        transform.position = Vector2.Lerp(bulletSpawn, bulletDisperse, t);

        Vector2 bulletDistance = transform.localScale;
        bulletDistance.x = Mathf.Lerp(1, 0, t);
        bulletDistance.y = Mathf.Lerp(1, 0, t);

        Vector2 planeHitbox = planePrefab.transform.position;
        

        if(bulletDistance.x <= 0f)
        {
            if(planeHitbox.x <= (bulletDisperse.x + 5) && planeHitbox.x >= (bulletDisperse.x - 5) && planeHitbox.y <= (bulletDisperse.y + 5) && planeHitbox.y >= (bulletDisperse.y - 5))
            {
                PlanePosition plane = planePrefab.GetComponent<PlanePosition>();
                plane.planeHit = true;
                Debug.Log("Plane Hit");
                Destroy(gameObject);

            }

            else
            {
             Destroy(gameObject);
            }
        }

       transform.localScale = bulletDistance;

    }
}
