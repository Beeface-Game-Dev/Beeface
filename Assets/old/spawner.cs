using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public GameObject worm;
    private float timeforspawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 5;

    // Update is called once per frame
    void Update ()
    {
        if (GameObject.FindWithTag("worm") != null)
        {
            if (timeforspawn <= 0)
            {
                Instantiate(worm, transform.position, Quaternion.identity);
                timeforspawn = startTimeBtwSpawn;
                if (startTimeBtwSpawn > minTime)
                {
                    startTimeBtwSpawn = startTimeBtwSpawn - decreaseTime;
                }
            }
            else
            {
                timeforspawn = timeforspawn - Time.deltaTime;
            }
        }

	}
    
}
