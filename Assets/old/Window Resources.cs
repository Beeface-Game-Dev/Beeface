using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WindowResources : MonoBehaviour
{
    private void Awake()
    {
        GameResources.OnfoodAmountChanged += delegate (object sender, EventArgs e) 
        {
            UpdateResourceTextObject();
        };
        UpdateResourceTextObject();
    }

    private void UpdateResourceTextObject()
    {
        transform.Find("foodAmount").GetComponent<Text>().text = "Food :" + GameResources.GetfoodAmount();
    }
}
