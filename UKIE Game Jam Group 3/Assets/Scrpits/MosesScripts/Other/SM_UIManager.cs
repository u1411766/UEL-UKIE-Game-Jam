using UnityEngine;
using UnityEngine.UI;


public class SM_UIManager : MonoBehaviour
{
    public Text tx_NortySurvived;
    public Text tx_KrispySurvived;
    public Text tx_McLatteSurvived;

    public Text tx_GameSpeed;
    public Text tx_PlayerScore;
    public Text tx_CountDownClock;
    public Text tx_LivesLeft;
    public Text tx_PlayerSelected;
    public Text tx_AbilityCooldown;

    SM_GameManager _gameManager;
    SM_ApplyBuffs targetPlayer;
    // Use this for initialization
    void Start()
    {
        _gameManager = FindObjectOfType<SM_GameManager>();
        targetPlayer = GameObject.Find("GameManager").GetComponent<SM_ApplyBuffs>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        TrackLives();
        tx_NortySurvived.text = SM_GameManager.in_NortySaved.ToString() + " Survived";
        tx_KrispySurvived.text = SM_GameManager.in_KrispySaved.ToString() + " Survived";
        tx_McLatteSurvived.text = SM_GameManager.in_McLatteSaved.ToString() + " Survived";

        tx_GameSpeed.text = "Game Speed: x" + SM_GameManager.in_gameSpeed;
        tx_PlayerScore.text = "Score: " + SM_GameManager.in_totalScore.ToString();
        if (targetPlayer.target == null)
        {
            return;
        }
        tx_PlayerSelected.text = targetPlayer.target.gameObject.name + "\n" + "Selected";

        if (targetPlayer.bl_isCoolingdown == false)
        {
            tx_AbilityCooldown.text = "Ability Ready";
        }
        else
        {
            tx_AbilityCooldown.text = "Ability Not Ready";
        }
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
            int seconds = Mathf.FloorToInt(SM_GameManager.fl_timeLeft - minutes * 60);
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
