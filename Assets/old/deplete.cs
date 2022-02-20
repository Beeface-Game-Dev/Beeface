using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplete : MonoBehaviour {

    public int crystalamount=2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(crystalamount<1)
        {
            Destroy(gameObject);
        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        crystalamount = crystalamount - 1;
        Debug.Log("crystalleft"+crystalamount);
    }
}
