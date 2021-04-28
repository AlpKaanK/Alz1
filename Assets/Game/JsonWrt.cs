using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class JsonWrt : MonoBehaviour
{
    Game1 game1;
    Game2 game2;
    //void Awake()
    //{
    //    PlayerPrefs.DeleteAll();
    //}
    void Create()
    {
        string path = Application.dataPath + "/ResultsGame1.txt";

        if (!File.Exists(path))
        {
            File.WriteAllText(path,"\n");

        }

        string content = "\n" + "{\"date\":" + System.DateTime.Now + "," + "\"timer1\":"+
            PlayerPrefs.GetFloat("timer") + "," +
            "\"wrong\":" + PlayerPrefs.GetInt("wrong") + "," +
            "\"game2score\":" +   PlayerPrefs.GetInt("score") + "}";
        File.AppendAllText(path, content);

    }

    // Start is called before the first frame update
    void OnApplicationQuit()
    {
        game1 = GetComponent<Game1>();
        game2 = GetComponent<Game2>();
        //game3_sc = GetComponent<Game3_Sc>();
        
        Create();
    }

    [System.Serializable]
    public class Save
    {
        public float timer1;
        public float timer2;
    }
    public Save save = new Save();
    // Update is called once per frame
    
}