using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShellsLoaded : MonoBehaviour
{
    //The following script is very similar in function to the example in required reading Health Bars 5.3 (https://www.youtube.com/watch?v=RRIlwBwDcK4)
    //See comments for explanation of functionality
    public float shots = 4; //there are 4 shots in single load
    public Slider slider;   //get the desired slider method that will be updated with the value

    // Start is called before the first frame update
    void Start()
    {
        slider.value = shots;   //set on screen slider with starting shot value
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            FireShell(1);   //slider must access function so call it and pass a value of 1, meaning that 1 shot should be deducted
        }

        if(shots < 0)   //reloads the shot counter once depleted
        {
            shots = 4;  //sets shot counter back to initial value
        }
    }

    public void FireShell(float shellsFired)
    {
        shots -= shellsFired;   //shellsFired is always a value of 1 when called, so shots will decrement by 1 when firing

        slider.value = shots;   //setting the on screen slider UI to the current shot count
    }
}
