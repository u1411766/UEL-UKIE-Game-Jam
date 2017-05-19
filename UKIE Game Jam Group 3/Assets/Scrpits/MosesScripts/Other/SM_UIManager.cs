using UnityEngine;
using UnityEngine.UI;

[SerializePrivateVariables]
public class SM_UIManager : MonoBehaviour
{
    Text tx_NortySurvived;
    Text tx_KrispySurvived;
    Text tx_McLatteSurvived;

    Text tx_GameSpeed;
    Text tx_PlayerScore;
    Text tx_CountDownClock;
    Text tx_LivesLeft;

    SM_GameManager _gameManager;
    // Use this for initialization
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<SM_GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        TrackLives();
        tx_NortySurvived.text = SM_GameManager.in_NortySaved.ToString() + " Survived";
        tx_KrispySurvived.text = SM_GameManager.in_KrispySaved.ToString() + " Survived";
        tx_McLatteSurvived.text = SM_GameManager.in_McLatteSaved.ToString() + " Survived";

        tx_GameSpeed.text = "Game Speed: x" + Time.timeScale.ToString();
        tx_PlayerScore.text = "Score: " + SM_GameManager.in_totalScore.ToString();
    }

    void Timer()
    {
        if (_gameManager.bl_isCountDown)
        {
            int minutes = Mathf.FloorToInt(SM_GameManager.fl_timeLeft / 60);
            int seconds = Mathf.FloorToInt(SM_GameManager.fl_timeLeft - minutes * 60);
            tx_CountDownClock.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
        else if (!_gameManager.bl_isCountDown)
        {
            int minutes = Mathf.FloorToInt(SM_GameManager.fl_timeLeft / 60);
            int seconds = Mathf.FloorToInt(SM_GameManager.fl_timeLeft + minutes * 60);
            tx_CountDownClock.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
    }

    void TrackLives()
    {
        if (SM_GameManager.in_LivesLeft > 1)
        {
            tx_LivesLeft.text = SM_GameManager.in_LivesLeft + " Lives Left";
        }
        else if (SM_GameManager.in_LivesLeft < 2)
        {
            tx_LivesLeft.text = SM_GameManager.in_LivesLeft + " Life Left";
        }
    }
}
