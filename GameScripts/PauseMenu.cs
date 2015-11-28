using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public CanvasGroup pauseMenu;
	public bool isPaused;
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			isPaused = true;
		}

		if(isPaused)
		{
			Time.timeScale = 0;
			pauseMenu.alpha = 1;
			pauseMenu.interactable = true;
			pauseMenu.blocksRaycasts = true;
		}
		else
		{
			Time.timeScale = 1;
			pauseMenu.alpha = 0;
			pauseMenu.interactable = false;
			pauseMenu.blocksRaycasts = false;
		}
	}

	public void exitToMainMenu()
	{
		Time.timeScale = 1;
		Application.LoadLevelAsync("MainMenu");
	}

	public void resumeGame()
	{
		isPaused = false;
	}
}
