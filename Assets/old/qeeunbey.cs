using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qeeunbey : MonoBehaviour
{
    public int health = 10;
    public int blomkos = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("beywerker"))
        {
            blomkos = blomkos + 1;
            Debug.Log("qeeun kos "+blomkos);
        }
    }
}

