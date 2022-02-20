using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script controls the Resource HUD and the overall resources the player has. This script should be attached to the Player object
public class ResourceManager : MonoBehaviour {

    public float ice; //The player's current stored ice
    public float maxIce; //The max amount of ice that can be stored
    public float iron; //The player's current stored iron
    public float maxIron; //The max amount of iron that can be stored
    public float power; //The player's current stored power
    public float maxPower; //The max amount of power that can be stored
    public float food; //The player's current stored food
    public float maxFood; //The max amount of food that can be stored
    public float oxygen; //The player's current stored oxygen
    public float maxOxygen; //The max amount of oxygen that can be stored
    public float population; //The player's current population
    public float maxPopulation; //The max amount of population that can be sustained

    public Text iceDisp; //The Text object that displays the ice values
    public Text ironDisp; //The Text object that displays the iron values
    public Text powerDisp; //The Text object that displays the power values
    public Text foodDisp; //The Text object that displays the food values
    public Text oxygenDisp; //The Text object that displays the oxygen values
    public Text populationDisp; //The Text object that displays the population values

    //public string files;
    public GameObject fileNameInput;
    //public GameObject InputField;
    public string Rfilename;
    //public GameObject DisplayName;

    public void btnSavefile()
    {
        Rfilename = fileNameInput.GetComponent<Text>().text;
        Debug.Log("aadfdfdfs " + Rfilename);
        // DisplayName.GetComponent<Text>().text = "displaying text" + filename;
    }

    public void populate()
    {
        population = gameObject.GetComponent<InputManager>().populations;
        //Debug.Log("population " + population);
    }
    public void Btnbuild()
    {
        food = gameObject.GetComponent<InputManager>().foods;
        maxPopulation = gameObject.GetComponent<InputManager>().popcap;
        maxFood = gameObject.GetComponent<InputManager>().maxfoods;
        maxIron = gameObject.GetComponent<InputManager>().maxmushroom;
    }
    public void BTNsave()
    {
        Save.SaveF(this);
    }
    public void BTNload()
    {
       Game data = Save.Load();

        food = data.food;
        ice = data.crystal;
        iron = data.mushroom;
        population = data.population;
        maxPopulation = data.maxpopulation;
        maxFood = data.maxfood;
        maxIron = data.maxmushroom;
        maxIce = data.maxcrystal;
    }
    // Update is called once per frame
    void Update ()
    {
        populate();
        //Debug.Log("populs " + population);
        if(food < 0)
        {
            food = 0;
        }
        if (ice < 0)
        {
            ice = 0;
        }
        if (iron < 0)
        {
            iron = 0;
        }
        if (population < 0)
        {
            population = 0;
        }
        iceDisp.text = "" + ice + "/" + maxIce; //Displays the current ice out of the max ice
        ironDisp.text = "" + iron + "/" + maxIron; //Displays the current iron out of the max iron
        //powerDisp.text = "" + power + "/" + maxPower; //Displays the current power out of the max power
        foodDisp.text = "" + food + "/" + maxFood; //Displays the current food out of the max food
        //oxygenDisp.text = "" + oxygen + "/" + maxOxygen; //Displays the current oxygen out of the max oxygen
        populationDisp.text = "" + population + "/" + maxPopulation; //Displays the current population out of the max population
    }
}
