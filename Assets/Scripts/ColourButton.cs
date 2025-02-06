using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourButton : MonoBehaviour
{
    public SpriteRenderer sr;
    public
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeColour()
    {
       sr.color = new Color(255f, 0f, 0f, 255f);
    }
}
