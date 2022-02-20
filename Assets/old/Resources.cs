using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ResourceType
{
    food//, mushroom, gems 
}


public class Resources : MonoBehaviour
{
    public ResourceType type;
    public int quantity;

    public UnityEvent onQuantityChange;

    public void GatherResource(int amount)//, Player gatherignPlayer)
    {
        quantity -= amount;

        int amountToGive = amount;

        if(quantity < 0)
        { amountToGive = amount + quantity; }

        if(quantity <= 0)
        { Destroy(gameObject); }

        if(onQuantityChange !=null)
        { onQuantityChange.Invoke(); }
    }
}
