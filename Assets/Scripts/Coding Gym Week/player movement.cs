using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float playerSpeed;
    public float gravityForce;
    public float jumpTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPosition = transform.position;

        if(playerPosition.y > 0)
        {
            gravityForce = 1;
        }
        else
        {
            gravityForce = 0;
        }



        if(Input.GetKey("d"))
        {
            playerPosition.x += playerPosition.x + playerSpeed;
        }

        if (Input.GetKey("a"))
        {
            playerPosition.x += playerPosition.x - playerSpeed;
        }

        if(Input.GetKey("w"))
        {
            jumpTime = 2;
        }
    }
}
