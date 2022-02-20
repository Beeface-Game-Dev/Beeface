using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class XObjectInfo : MonoBehaviour
{
    /*public GameObject iconCam;
    public GameObject selectionIndicator;

    public CanvasGroup InfoPanel;

    public bool isSelected = false;
    public bool isUnit;

    public string objectName;
    public Text nameDisp;

    public Slider HB;
    public Text healthDisp;
    public int health;
    public int maxhealth;

    public Slider SHB;
    public Text shroomDisp;
    public int shroom;
    public int maxshroom;

    public int patk;
    public Text patkDisp;
    public int pdef;
    public Text pdefDisp;
    public int eatk;
    public Text eatkDisp;
    public int edef;
    public Text edefDisp;

    public enum Level 
    {
        Recruit
    }
    public Level level;
    public Text levelDisp;

    public int CrystalAbs;
    public Text CrystalAbsDisp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        selectionIndicator.SetActive(isSelected);

        if(maxshroom <= 0)
        {
            SHB.gameObject.SetActive(false);
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        HB.maxValue = maxhealth;
        HB.value = health;

        SHB.maxValue = maxshroom;
        SHB.value = shroom;

        iconCam.SetActive(isSelected);

        nameDisp.text = objectName;
        healthDisp.text = "HP: " + health;
        shroomDisp.text = "SHP: " + shroom;
        patkDisp.text = "PATK: " + patk;
        pdefDisp.text = "PDEF: " + pdef;      
        eatkDisp.text = "EATK: " + eatk; 
        edefDisp.text = "EDEF: " + edef;
        levelDisp.text = ""+ level;
        CrystalAbsDisp.text = "Crystals: " + CrystalAbs;

        if (isSelected)
        {
            InfoPanel.alpha = 1;
            InfoPanel.blocksRaycasts = true;
            InfoPanel.interactable = true;
        }
        else
        {
            InfoPanel.alpha = 0;
            InfoPanel.blocksRaycasts = false;
            InfoPanel.interactable = false;

        }
    }*/
       
}
