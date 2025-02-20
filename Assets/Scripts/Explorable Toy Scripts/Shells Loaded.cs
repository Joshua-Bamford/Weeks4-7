using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShellsLoaded : MonoBehaviour
{
    public float shots = 4;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = shots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            FireShell(1);
        }

        if(shots < 0)
        {
            shots = 4;
        }
    }

    public void FireShell(float shellsFired)
    {
        shots -= shellsFired;

        slider.value = shots;
    }
}
