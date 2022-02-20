using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeface : MonoBehaviour
{//GAAN NIE WERK VIR MOBILE
    private void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0, 0, -1);
        }
    }
}
