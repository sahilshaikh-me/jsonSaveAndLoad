using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.UnityConverters;
using Newtonsoft.Json.UnityConverters.Math;
using Newtonsoft.Json.Converters;

public class SaveDataManager : MonoBehaviour
{

    string saveFile;
    [System.Serializable]
    public class data
    {
        public string name;
        public List<Vector2> Position;

    }

    public data[] datasave;

    void Start()
    {
        saveFile = Application.persistentDataPath + "/gamedata.json";
    }
   
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            writeFile();
        } 
        if (Input.GetKeyDown(KeyCode.R))
        {
            readFile();
        }

    }

    public void readFile()
    {
        // Does the file exist?
        if (File.Exists(saveFile))
        {
            //File.ReadAllText(saveFile)
            //JsonUtility.FromJsonOverwrite(File.ReadAllText(saveFile), datasave);
            string jsonget = File.ReadAllText(saveFile);
          
            datasave = JsonConvert.DeserializeObject<data[]>(jsonget); ;

           
               
            // Work with JSON
        }
    }

    public void writeFile()
    {
        // Work with JSON
        string allPlayersArrayJson = JsonConvert.SerializeObject(datasave,Formatting.Indented);
       // string allPlayersArrayJson = JsonUtility.ToJson(datasave);
        Debug.Log(allPlayersArrayJson);

        File.WriteAllText(saveFile, allPlayersArrayJson); Debug.Log(Application.persistentDataPath);
    }
}

