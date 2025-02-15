using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 tankPos = transform.position;
        if (Input.GetKey("d"))
        {
            tankPos.x += speed;
        }

        if (Input.GetKey("a"))
        {
            tankPos.x += speed * (-1);
        }
        transform.position = tankPos;
    }
}
