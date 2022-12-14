  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float timeValue = 900;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;

        }
        else
        {
            timeValue += 90;
        }
        DisplayTime(timeValue);
    }
    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float millisecons = timeToDisplay % 1 * 1000/10;
        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, millisecons);
    }
}
