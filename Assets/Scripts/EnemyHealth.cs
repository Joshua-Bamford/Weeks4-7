using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public SpriteRenderer abracadabra;
    public float healthStatus;
    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);     //may have to set the Transform.Position as a Vector 2 or 3 aswell
    
    void Start()
    {
        healthStatus = 10f;
    }

 
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && mousePos == transform.position)    //I feel like Im close, but ran out of time in class
        {
            healthStatus--;
        }

        if (healthStatus <= 0)
        {
            abracadabra.enabled = false;
        }
    }
}
