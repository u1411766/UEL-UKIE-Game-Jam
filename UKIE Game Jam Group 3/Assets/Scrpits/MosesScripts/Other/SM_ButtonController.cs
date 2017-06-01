using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM_ButtonController : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject Instructions;
	// Use this for initialization
	void Start () {
        if (MainMenu != null && Instructions != null)
        {
            MainMenu.gameObject.SetActive(true);
            Instructions.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevel(int in_leveltoLoad)
    {
        SceneManager.LoadSceneAsync(in_leveltoLoad);
    }

    public void GotoMainMenu()
    {
        MainMenu.gameObject.SetActive(true);
        Instructions.gameObject.SetActive(false);
    }

    public void GotoInstructions()
    {
        MainMenu.gameObject.SetActive(false);
        Instructions.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
