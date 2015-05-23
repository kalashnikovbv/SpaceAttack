using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuController : MonoBehaviour
{
	public GameObject pauseMenuPanel;

	public GameController gameController;

	void Start ()
	{
		pauseMenuPanel.SetActive (false);
	}

	public void OpenPauseMenu ()
	{
		pauseMenuPanel.SetActive (true);
		gameController.PauseMusic ();

		Time.timeScale = 0.0F;
	}

	public void ClosePauseMenu ()
	{
		pauseMenuPanel.SetActive (false);
		gameController.PlayMusic ();

		Time.timeScale = 1.0F;
	}

	public void pauseButtonPressed ()
	{
		if (pauseMenuPanel.activeSelf)
		{
			ClosePauseMenu ();
		} 
		else
		{
			OpenPauseMenu ();
		}
	}

	public void quitLevel ()
	{
		Time.timeScale = 1.0F;
		Application.LoadLevel ("MainMenu");
	}
}
