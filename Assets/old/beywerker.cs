using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beywerker : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public Vector2 targetPosition;
   // private Vector2 Posup;
    public int health = 3;

    public bool selected = false;
    public bool movement = false;
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        if (movement == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5);
        }

        /*if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Posup = new Vector2(transform.position.x, transform.position.y+1);
            transform.position = Posup;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Posup = new Vector2(transform.position.x, transform.position.y - 1);
            transform.position = Posup;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Posup = new Vector2(transform.position.x-1, transform.position.y);
            transform.position = Posup;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Posup = new Vector2(transform.position.x+1, transform.position.y);
            transform.position = Posup;
        }*/
    }
    
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameObject.FindWithTag("beywerker"))
            {
                // Instead of directly setting this value, set it to the opposide of what it already is
                selected = !selected;
                // And now you can shorten your code significantly as well. 
                // If 'selected' was 'false' before, after pressing the button it's now 'true' so the code below would execute
                if (selected == true)
                {
                    movement = true;
                    //gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                }
                // If  on the other hand 'selected' was 'true' before, after pressing the button it's now 'false' so the code below would execute
                else
                {
                    movement = false;
                    //gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                }
            }
        }
    }
}
