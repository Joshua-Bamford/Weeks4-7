using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshairs : MonoBehaviour
{
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        //Line 21-22 derived from Week 6 coding gym
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //gets value of mouse position and stores it in Vector2 variable
       transform.position = mousePos;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab);
        }
    }
}
