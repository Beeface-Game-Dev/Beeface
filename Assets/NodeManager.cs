using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script holds all of the information required for resource nodes. It gets attached to all resource nodes
public class NodeManager : MonoBehaviour {

    public enum ResourceTypes { Ice, Iron, Food} //Possible resource types

    public ResourceTypes resourceType; //Creates the enum for this node

    public float availableResource; //How much can be harvested from this node

    public int gatherers; //How many units gathering from this node

	// Use this for initialization
	void Start () {
        StartCoroutine(ResourceTick()); //Starts the ResourceTick() IEnumerator
	}
	
	// Update is called once per frame
	void Update () {
		
        if(availableResource <= 0) //Is this node out of resources?
        {
            //Destroy(gameObject); //Destroy this object
        }
	}

    //Increments the available resources down
    public void ResourceGather()
    {
        if (gatherers != 0) //Are there any units gathering from this node?
        {
            availableResource -= gatherers; //Subtract the current number of units gathering from the available resources
        }
    }

    //This starts the incrementation process
    IEnumerator ResourceTick()
    {
        while (true) //Is this CoRoutine running?
        {
            yield return new WaitForSeconds(1); //Wait for 1 second
            ResourceGather(); //Calls the ResourceGather() method
        }
    }
}
