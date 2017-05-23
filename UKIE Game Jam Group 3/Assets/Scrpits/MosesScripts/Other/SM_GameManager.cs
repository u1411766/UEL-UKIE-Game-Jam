using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SM_GameManager : MonoBehaviour
{
    public float fl_setTimer;
    public bool bl_isCountDown;
    public int in_setLives;

    internal static int in_totalScore;
    internal static int in_NortySaved;
    internal static int in_KrispySaved;
    internal static int in_McLatteSaved;
    internal static int in_LivesLeft;
    internal static float fl_timeLeft;

    // Use this for initialization
    void Awake()
    {
        in_LivesLeft = in_setLives;
        fl_timeLeft = fl_setTimer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ControllTime();
        TimeKeeper();
    }

    void ControllTime()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.timeScale <= 4)
        {
            if (Time.timeScale >= 1)
            {
                Time.timeScale++;
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (Time.timeScale <= 1)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale--;
            }
        }
    }

    void TimeKeeper()
    {
        if (bl_isCountDown)
        {
            fl_timeLeft -= Time.deltaTime;
        }
        else if (!bl_isCountDown)
        {
            fl_timeLeft += Time.deltaTime;
        }        
    }
}
