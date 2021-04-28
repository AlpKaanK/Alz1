using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Game1 : MonoBehaviour
{
    int i = 0;
    public int wrong = 0;
    public Text text;
    public Button b1;
    public Button b2;
    public Button b3;
    public TextAsset textJSON;
    public bool check = true;
    public float timer = 0.0f;
    [System.Serializable]   
    public class Player
    {
        public string header;
        public List<string> words;
        public List<bool> check;
        
    }
    [System.Serializable]
    public  class PlayerList
    {
        public Player[] player;
    }

    public PlayerList myPlayerlist = new PlayerList();
    // Start is called before the first frame update
    void Start()
    {
        myPlayerlist = JsonUtility.FromJson<PlayerList>(textJSON.text);

        text.GetComponent<Text>().text = myPlayerlist.player[0].header;
        b1.GetComponentInChildren<Text>().text = myPlayerlist.player[0].words[0];
        b2.GetComponentInChildren<Text>().text = myPlayerlist.player[0].words[1];
        b3.GetComponentInChildren<Text>().text = myPlayerlist.player[0].words[2];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(PlayerPrefs.GetFloat("timer"));
        }
        timer = (int)(Time.timeSinceLevelLoad);
        if (i == 9)
        {
           
            PlayerPrefs.SetFloat("timer", timer);
            PlayerPrefs.SetInt("wrong", wrong);

        }


    }



    public void Check()
    {
        //for(int i = 0; i < myPlayerlist.player.Length; i++) 
        
        
        while(i  <= myPlayerlist.player.Length-1 ){ 

        text.GetComponent<Text>().text = myPlayerlist.player[i].header;
        b1.GetComponentInChildren<Text>().text = myPlayerlist.player[i].words[0];
        b2.GetComponentInChildren<Text>().text = myPlayerlist.player[i].words[1];
        b3.GetComponentInChildren<Text>().text = myPlayerlist.player[i].words[2];
            Debug.Log(EventSystem.current.currentSelectedGameObject.GetComponent<Button>().name);
            // foreach()
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>().name == "b1" && myPlayerlist.player[i].check[0] == true ||
               EventSystem.current.currentSelectedGameObject.GetComponent<Button>().name == "b2" && myPlayerlist.player[i].check[1] == true ||
               EventSystem.current.currentSelectedGameObject.GetComponent<Button>().name == "b3" && myPlayerlist.player[i].check[2] == true)
            {

                Debug.Log(i);
                i = i + 1;
            }
            else
            {

                wrong = wrong + 1;
                break;
            
            }
        }
    }



}

