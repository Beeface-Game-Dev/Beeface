using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class allButtons : MonoBehaviour
{
    public Animator objectivepanelAnim;
    private bool isobjectivevisible = true;
    // public Animator minimapAnim;

    public void btnObjectiveAnim()
    {
        // objectivepanelAnim.SetBool("open", true);

            if (isobjectivevisible)
            {
                isobjectivevisible = false;
            }
            else
            {
                isobjectivevisible = true;
            }      

        if (isobjectivevisible)
        {
            objectivepanelAnim.SetBool("open", true);
        }
        else
        {
            objectivepanelAnim.SetBool("open", false);
        }
    }
}
