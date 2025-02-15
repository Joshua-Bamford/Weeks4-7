using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankRound : MonoBehaviour
{
    public float bulletVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bulletPosition = transform.position;
        bulletPosition.x += bulletVelocity;
        transform.position = bulletPosition;
    }
}
