using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshairs : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float scaleValue;
    // Update is called once per frame
    void Update()
    {
        //Line 12-13 derived from Week 6 coding gym
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //gets value of mouse position and stores it in Vector2 variable
       transform.position = mousePos;   //updates game object position to match that of the cursor

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab);  //firing button. only creates instance as every other aspect of the bullet prefab is handled by the bullet's script
        }
        

    }

    public void ScopeSize(float scaleValue) //function used by right side slider
    {
        Vector2 reticleSize = transform.localScale;
        reticleSize.x = scaleValue; //scale value is retrieved from slider input and updates reticle size
        reticleSize.y = scaleValue;
        transform.localScale = reticleSize; //changes actual crosshair size to match changed value
    }
}
