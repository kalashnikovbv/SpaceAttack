using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuController : MonoBehaviour
{
	public GameObject pauseMenuPanel;
	public GameController gameController;

	public Text loadingText;

	void Start ()
	{
		loadingText.text = "";

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
		loadingText.text = "Loading...";
		Time.timeScale = 1.0F;

		Application.LoadLevel ("MainMenu");
	}
}
