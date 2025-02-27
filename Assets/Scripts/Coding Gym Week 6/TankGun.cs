using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gun targeting
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //gets value of mouse position and stores it in Vector3 variable
        mousePos.z = 0; //Makes the conversion from the direction Vector2 to mousePos Vector3 - transform work by rendering the Z value to be constant
        Vector2 direction = mousePos - transform.position;
        transform.up = direction;   //up is a built in vector that gets the orientation of the Y axis (green transform arrow) of the game object
        //by making up vector equal the direction, the green transform axis arrow should always point to the mouse

        //bullet spawner
        if (Input.GetMouseButtonDown(0)) 
        {
            Instantiate(bulletPrefab, transform);  //Exactly what it says, instantiates the bullet prefab. The movement and destruction is handled by the TankRound script on the prefab
        }
    }
}
