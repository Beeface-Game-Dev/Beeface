using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float panSpeed = 7;
    float panDetect = 15;

    float oldAltitide;
    float altitude;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movex = Input.GetAxis("Horizontal") * panSpeed * Time.deltaTime;
        float movez = Input.GetAxis("Vertical") * panSpeed * Time.deltaTime;
        float movey = Input.GetAxisRaw("Mouse ScrollWheel");
        float clampedy = movey;

        float xPos = Input.mousePosition.x;
        float yPos = Input.mousePosition.y;

        altitude = Terrain.activeTerrain.SampleHeight(transform.position);

        if(oldAltitide != altitude)
        {
            AltAdjust();
            oldAltitide = altitude;
        }

        if(transform.position.y >= -5 && transform.position.y <= 1000)
        {
            movey *= 15;
            transform.Translate(new Vector3(0, movey, 0));
        }

        if (Input.GetKey(KeyCode.A) || (xPos > 0 && xPos < panDetect))
        {
            movex = movex - panSpeed;
        }
        else if (Input.GetKey(KeyCode.D) || xPos < Screen.width && xPos > Screen.width - panDetect)
        {
            movex = movex + panSpeed;
        }
        if (Input.GetKey(KeyCode.W) || yPos < Screen.height && yPos > Screen.height - panDetect)
        {
            movez = movez + panSpeed;
        }
        else if (Input.GetKey(KeyCode.S) || yPos > 0 && yPos < panDetect)
        {
            movez = movez - panSpeed;
        }

        transform.Translate(new Vector3(movex, Input.GetAxis("Mouse ScrollWheel") * panSpeed, movez));
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 10 + altitude, 1000 + altitude), transform.position.z);
    }

    public void AltAdjust()
    {
        float newHeight = transform.position.y;
        Vector3 pos = transform.position;
        pos.y = altitude;
        pos.y += newHeight;

        transform.position = pos;
    }
}
