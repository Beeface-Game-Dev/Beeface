using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XInputmanger : MonoBehaviour
{
   /* public float rotateSpeed;
    public float rotateAmount;

    private Quaternion rotation;

    public float panSpeed;
    private float panDetect = 15f;
    private float minHeight = 100f;
    private float maxHeight = 800f;

    private Vector2 boxStart;
    private Vector2 boxEnd;
    public Texture boxTex;
    private Rect selectBox;

    public GameObject selectedObject;
    private ObjectInfo selectedInfo;

    private GameObject[] units;

    // Start is called before the first frame update
    void Start()
    {
        rotation = Camera.main.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //MoveCamera();
        //RotateCamera();

        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("leftclick");
            LeftClick();
        }

        if(Input.GetMouseButton(0) && boxStart == Vector2.zero)
        {
            boxStart = Input.mousePosition;
        }
        else if(Input.GetMouseButton(0) && boxStart != Vector2.zero)
        {
            boxEnd = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            units = GameObject.FindGameObjectsWithTag("Selectable");
            MultiSelect();
        
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Camera.main.transform.rotation = rotation;
        }

        selectBox = new Rect(boxStart.x, Screen.height - boxStart.y, boxEnd.x - boxStart.x, -1 * ((Screen.height - boxStart.y) - (Screen.height - boxEnd.y)));
    }
    public void MultiSelect()
    {
        foreach (GameObject unit in units)
        {
            if (unit.GetComponent<ObjectInfo>().isUnit)
            {
                Vector2 unitPos = Camera.main.WorldToScreenPoint(unit.transform.position);
                if(selectBox.Contains(unitPos, true))
                {
                    //if(!hasPrimary)
                    //{
                    //    primaryObject = unit;
                    //    unit.GetComponent<ObjectInfo>().isPrimary = true;
                    //}

                    unit.GetComponent<ObjectInfo>().isSelected = true;
                }
            }   
        }
        boxStart = Vector2.zero;
        boxEnd = Vector2.zero;
    }

    public void LeftClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1000))
        {
            if(hit.collider.tag == "Ground")
            {
                selectedInfo.isSelected = false;
               // selectedInfo.isPrimary = false;
                selectedObject = null;

                 //   unit.GetComponent<ObjectInfo>().isSelected = false;
                
              //  selectedInfo = null;

                Debug.Log("Deselected");

            }else if(hit.collider.tag == "Selectable")
            {
                //foreach(GameObject unit in units)
                //{
                //    unit.GetComponent<ObjectInfo>().isSelected = false;
                //}

                //if (hasPrimary)
                //{
                //    selectedInfo.isSelected = false;
                //    selectedInfo.isPrimary = false;
                //    selectedObject = null;
                //}

                    selectedObject = hit.collider.gameObject;
                    selectedInfo = selectedObject.GetComponent<ObjectInfo>();

                    selectedInfo.isSelected = true;
                  //  selectedInfo.isPrimary = true; 

                    Debug.Log("Selected" + selectedInfo.objectName);             
            }
        }
    }

  /*  void MoveCamera()
    {
        float movex = Camera.main.transform.position.x;
        float movez = Camera.main.transform.position.z;
        float movey = Camera.main.transform.position.y;

        float xPos = Input.mousePosition.x;
        float yPos = Input.mousePosition.y;

        if(Input.GetKey(KeyCode.A)||(xPos > 0 && xPos < panDetect))
        {
            movex = movex - panSpeed;
        }
        else if(Input.GetKey(KeyCode.D)|| xPos < Screen.width && xPos > Screen.width - panDetect)
        {
            movex = movex + panSpeed;
        }
        if(Input.GetKey(KeyCode.W) || yPos < Screen.height && yPos > Screen.height - panDetect)
        {
            movez = movez + panSpeed;
        }
        else if(Input.GetKey(KeyCode.S)|| yPos > 0 && yPos < panDetect)
        {
            movez = movez - panSpeed;
        }

        movey -= Input.GetAxis("Mouse ScrollWheel") * (panSpeed * 20);
        movey = Mathf.Clamp(movey, minHeight, maxHeight);

        Vector3 newPos = new Vector3(movex,movey,movez);

        Camera.main.transform.position = newPos;
    }
    void RotateCamera ()
    {
        Vector3 origin = Camera.main.transform.eulerAngles;
        Vector3 destination = origin;

        if(Input.GetMouseButton(2))
        {
            destination.x = destination.x - Input.GetAxis("Mouse Y") * rotateAmount;
            destination.y = destination.y + Input.GetAxis("Mouse X") * rotateAmount;
        }
        if(destination != origin)
        {
            Camera.main.transform.eulerAngles = Vector3.MoveTowards(origin, destination, Time.deltaTime * rotateSpeed);
        }
    }
    void OnGUI()
    {
        if(boxStart != Vector2.zero && boxEnd != Vector2.zero)
        {
            GUI.DrawTexture(selectBox, boxTex);

        }
    }*/
}
