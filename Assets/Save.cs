using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
//public static class Save
public static class Save
{
    //public int number = 0;
    //private InputField fileNameInput;
    //string filename;
    public static List<Game> savedGames = new List<Game>();
    public static string filename;

    //Inputmanager IM = new Inputmanager();
    public static void SaveF(ResourceManager RM)
    {
        //number = number + 1;
        //filename.text = FileNameInput;
        Game gamedata = new Game(RM);

        savedGames.Add(Game.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream("C:/Users/Lenard/Desktop/beeface/saved files" + "/savedGame "+gamedata.filename+".save", FileMode.Create);
        //FileStream file = new File.Create("C:/Users/Lenard/Desktop/beeface/saved files" + "/savedGame"+ filename+".save");
        
        bf.Serialize(file, gamedata);
        file.Close();

        Debug.Log("stats " + gamedata);
    }

    public static Game Load()
    {
        string path = "C:/Users/Lenard/Desktop/beeface/saved files" + "/savedGame.save";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream("C:/Users/Lenard/Desktop/beeface/saved files" + "/savedGame.save", FileMode.Open);
            Game gamedata = bf.Deserialize(file) as Game;
            file.Close();
            return gamedata;
            Debug.Log("file was loaded");
           // IM.saveSpawn();
        }
        else
        {
            Debug.Log("save file not found in path " + path);
            return null;
        }
    }

        /* public List<int> livingTargetPositions = new List<int>();
         public List<int> livingTargetsTypes = new List<int>();

         public int hits = 0;
         public int shots = 0;
         private Save CreateSaveGameObject()
         {
             Save save = new Save();
             int i = 0;
             foreach (GameObject targetGameObject in targets)
             {
                 ObjectInfo target = targetGameObject.GetComponent<ObjectInfo>();
                 if (target.activeRobot != null)
                 {
                     save.livingTargetPositions.Add(target.position);
                     save.livingTargetsTypes.Add((int)target.activeRobot.GetComponent<Robot>().type);
                     i++;
                 }
             }
             save.hits = hits;
             save.shots = shots;

             return save;
         }
         public void SaveGame()
         {
             Save save = CreateSaveGameObject();

             BinaryFormatter bf = new BinaryFormatter();
             FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
             bf.Serialize(file, save);
             file.Close();

             hits = 0;
             shots = 0;
             shotsText.text = "Shots: " + shots;
             hitsText.text = "Hits: " + hits;

             ClearRobots();
             ClearBullets();
             Debug.Log("Game Saved");
         }*/
}
