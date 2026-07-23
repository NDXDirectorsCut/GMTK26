using UnityEngine;
using System;
using System.Collections;
using TMPro;

public class MinigameLogic : MonoBehaviour
{
    public int gameTime = 5;
    public bool failed = false;
    public bool successed = false;
    public bool successOnWait = false;
    int activeTime;
    TMP_Text timerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerText = transform.Find("Timer").GetComponentInChildren<TMP_Text>();
        activeTime = gameTime;
    }

    void OnEnable()
    {
        activeTime = gameTime;
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while(activeTime>0)
        {
            yield return new WaitForSecondsRealtime(1f);
            activeTime--;
            if(activeTime == 0)
            {
                if(successOnWait == false)
                {
                    failed = true;
                }
                else
                {
                    successed = true;
                }
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = activeTime.ToString();
    }
}
