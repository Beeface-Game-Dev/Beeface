using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour {

    public static int blomkos=0;
    public static int pollen=0;
    public static int crystal = 0;
    public static int mushroom = 0;
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "flower food")
        {
            blomkos = blomkos + 1;
        }
        if (other.name == "crystal")
        {
            crystal = crystal + 1;
        }
        if (other.name == "flower pollen")
        {
            pollen = pollen + 1;
        }
        if (other.name == "mushroom")
        {
            mushroom = mushroom + 1;
        }
        Debug.Log("food "+blomkos+"crystal"+crystal+"pollen"+pollen+"shrrom"+mushroom);
        
            if (other.CompareTag("QueenBee"))
            {
               blomkos = blomkos - 1;
               Debug.Log("food " + blomkos);
            }
    }
}
