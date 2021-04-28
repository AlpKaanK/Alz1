using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3 : MonoBehaviour
{

    public Light myLight;
    public float time1;



    // Intensity Variables
    public bool changeIntensity = false;
    public float intensitySpeed = 1.0f;
    public float maxIntensity = 10.0f;


    // Color variables
    public bool changeColors = false;
    public float colorSpeed = 0.2f;
    public Color startColor;
    public Color endColor;
    public bool repeatColor = true;
    public int score = 0;
    bool count = true;
    float startTime;

    // Use this for initialization
    void Start()
    {
        myLight = GetComponent<Light>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {




        if (changeColors)
        {
            if (repeatColor)
            {
                float t = (Mathf.Sin(Time.time - startTime * colorSpeed));
                myLight.color = Color.Lerp(startColor, endColor, t);

            }
            else
            {
                float t = Time.time - startTime * colorSpeed;
                myLight.color = Color.Lerp(startColor, endColor, t);
            }
        }


        //output part
        if (myLight.color == Color.green && count == true)
        {
            time1 += Time.deltaTime;


            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Debug.Log(myLight.color);
                Debug.Log(time1);
                score = score + 1;
                count = false;
            }

        }
        if (myLight.color != Color.green)
        {
            count = true;
        }



    }
}