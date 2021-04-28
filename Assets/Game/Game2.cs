using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Game2 : MonoBehaviour
{
    private string[] array1 = { "X", "Y", "Z", "H", "G", "V", "C", "Z", "N", "B" };
    private string[] array2 = { "A", "Y", "Z", "H", "G", "V", "C", "Z", "N", "B" };
    public string[] array3;
    public TextAsset textJSON;
    public Button button0;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;
    public Button button8;
    public Button button9;
    bool clickcheck = false;
    bool func_check = true;
    public static float timer = 3.0f;
    public Text randomText;
    public Text randomText1;
    public Text randomText2;
    public Text randomText3;
    public Text randomText4;
    public Text randomText5;
    public Text randomText6;
    public Text randomText7;
    public Text randomText8;
    public Text randomText9;
    public Text randomText10;
    public Text randomText11;
    public Text randomText12;
    public Text randomText13;
    public Text randomText14;
    public Text randomText15;
    public Text randomText16;
    public Text randomText17;
    public Text randomText18;
    public Text randomText19;
    public Text textbox;
    public int score;
    public int _try = 10;
    [System.Serializable]
    public class Player
    {
        public List<string> correct;
        public List<string> wrong;
        public string[] words; 
    }
    [System.Serializable]
    public class PlayerList
    {
        public Player[] player;
    }

    public PlayerList myPlayerlist = new PlayerList();


    void Awake()
    {

        myPlayerlist = JsonUtility.FromJson<PlayerList>(textJSON.text);
        for (int i = 0; i < 10; i++)
        {
            array1[i] = myPlayerlist.player[0].correct[i];
            array2[i] = myPlayerlist.player[0].wrong[i];
        }
        array3 = array1.Concat(array2).ToArray();

    }

    void Start()
    {
        if (clickcheck == true)
        {
            Invoke("TimerStart", 0.1f);
        }
        Invoke("Reshuffle", 0f);
    }


    void Update()
    {

        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                clickcheck = true;
            }

            if (clickcheck == true)
            {
                Invoke("TimerStart", 0.1f);
            }
            else
            {
                CancelInvoke("TimerStart");
            }
        }


        if (timer < 0 && func_check == true)
        {
            Invoke("SecondPhase", 0f);
            func_check = !func_check;

        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.GetComponent<Button>().GetComponentInChildren<Text>().text);
        }

    }




    public void Reshuffle()
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < array1.Length; t++)
        {
            string tmp = array1[t];
            int r = Random.Range(t, array1.Length);
            array1[t] = array1[r];
            array1[r] = tmp;
        }
        randomText.text  = array1[0];
        randomText1.text = array1[1];
        randomText2.text = array1[2];
        randomText3.text = array1[3];
        randomText4.text = array1[4];
        randomText5.text = array1[5];
        randomText6.text = array1[6];
        randomText7.text = array1[7];
        randomText8.text = array1[8];
        randomText9.text = array1[9];

        // Knuth shuffle kullanıldı
    }
    public void SecondPhase()
    {
        if (randomText.enabled != false)
        {

            for (int t = 0; t < array3.Length; t++)
            {
                string tmp = array3[t];
                int r = Random.Range(t, array3.Length);
                array3[t] = array3[r];
                array3[r] = tmp;
            }
            randomText.text = array3[0];
            randomText1.text = array3[1];
            randomText2.text = array3[2];
            randomText3.text = array3[3];
            randomText4.text = array3[4];
            randomText5.text = array3[5];
            randomText6.text = array3[6];
            randomText7.text = array3[7];
            randomText8.text = array3[8];
            randomText9.text = array3[9];
            randomText10.text = array3[10];
            randomText11.text = array3[11];
            randomText12.text = array3[12];
            randomText13.text = array3[13];
            randomText14.text = array3[14];
            randomText15.text = array3[15];
            randomText16.text = array3[16];
            randomText17.text = array3[17];
            randomText18.text = array3[18];
            randomText19.text = array3[19];


        }


    }
    public void Appear()
    {
        if (randomText.enabled == false)
        {

            randomText.GetComponent<Text>().enabled = true;
            randomText1.GetComponent<Text>().enabled = true;
            randomText2.GetComponent<Text>().enabled = true;
            randomText3.GetComponent<Text>().enabled = true;
            randomText4.GetComponent<Text>().enabled = true;
            randomText5.GetComponent<Text>().enabled = true;
            randomText6.GetComponent<Text>().enabled = true;
            randomText7.GetComponent<Text>().enabled = true;
            randomText8.GetComponent<Text>().enabled = true;
            randomText9.GetComponent<Text>().enabled = true;



        }
    }

    void TimerStart()
    {

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            textbox.text = Mathf.Round(timer).ToString();
        }
    }

    public void ScoreCheck()
    {
        if (func_check == false)
        {


            {

                for (int i = 0; i < array1.Length; i++)
                {
                    if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>().GetComponentInChildren<Text>().text == array1[i]  )
                        
                    {

                        _try--;
                        score++;
                        break;
                    }


                }
                for (int j = 0; j < array2.Length; j++)
                {
                    if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>().GetComponentInChildren<Text>().text == array2[j])
                    {

                        _try--;
                        break;
                    }

                }
            }
            if (_try == 0)
            {
                //Invoke
                Debug.Log("GameOver");
                Debug.Log(score);
                PlayerPrefs.SetInt("score", score);


            }

        }


    }

}
