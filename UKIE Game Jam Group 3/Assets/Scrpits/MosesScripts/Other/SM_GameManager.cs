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
    internal static int in_gameSpeed = 1;

    // Use this for initialization
    void Awake()
    {
        in_LivesLeft = in_setLives;
        fl_timeLeft = fl_setTimer;
        in_gameSpeed = (int)Time.timeScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ControllTime();
        TimeKeeper();
    }

    void ControllTime()
    {
        if (Input.GetKeyDown(KeyCode.F) && in_gameSpeed <= 4)
        {
            in_gameSpeed += 1;
        }
        if (Input.GetKeyDown(KeyCode.G) && in_gameSpeed > 1)
        {
            in_gameSpeed -= 1;
        }
        GameTime();
    }

    void GameTime()
    {
        switch (in_gameSpeed)
        {
            case 1:
                Time.timeScale = 1;
                break;
            case 2:
                Time.timeScale = 2;
                break;
            case 3:
                Time.timeScale = 3;
                break;
            case 4:
                Time.timeScale = 4;
                break;
            case 5:
                Time.timeScale = 5;
                break;
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