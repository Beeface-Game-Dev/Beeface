using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonResume : MonoBehaviour
{
    public GameObject PauseMenu;
    InputManager MGR = new InputManager();
    bool paus;

    public void run()
    {
        paus = MGR.paused;
        Debug.Log("p " + paus);

            Time.timeScale = 1f;
            PauseMenu.gameObject.SetActive(false);
            paus = false;
    }
}
