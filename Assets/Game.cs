
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Game
{
    public static Game current;
    public float food;
    public float mushroom;
    public float crystal;
    public float population;
    public float maxpopulation;
    public float maxfood;
    public float maxmushroom;
    public float maxcrystal;
    public float beefaces;

    public GameObject fileNameInput;
    public string filename;
    //public GameObject DisplayName;

    /* public string knight;
     public string rogue;
     public string wizard;*/

    public Game(ResourceManager RM)
    {
        /* knight = "knight";
         rogue = "rogue";
         wizard = "wizard";*/
        //food = RM.food;
        food = RM.food;
        mushroom = RM.iron;
        crystal = RM.ice;
        population = RM.population;
        maxfood = RM.maxFood;
        maxpopulation = RM.maxPopulation;
        maxmushroom = RM.maxIron;
        maxcrystal = RM.maxIce;
        filename = RM.Rfilename;
    }
    public void minion()
    {
        beefaces = population;
    }
}
