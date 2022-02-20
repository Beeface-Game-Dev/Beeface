using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worm : MonoBehaviour {

    public int health = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("beywerker"))
        {
            other.GetComponent<beywerker>().health = health - 1;
            Debug.Log(other.GetComponent<beywerker>().health);
            Destroy(gameObject);
        }
    }
}
