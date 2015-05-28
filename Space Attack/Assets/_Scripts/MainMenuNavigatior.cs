using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuNavigatior : MonoBehaviour
{
	public GameObject mainMenuPanel;

	public GameObject selectLavelPanel;
	public GameObject howToPlayPanel;
	public GameObject settingsPanel;
	public GameObject highScorePanel;

	public Text loadingText;

	void Start ()
	{
		loadingText.text = "";

		ShowMainMenuPanel ();
	}

	public void OpenSelectLevelPanel ()
	{
		mainMenuPanel.SetActive (false);
		selectLavelPanel.SetActive (true);
	}

	public void OpenHowToPlayPanel ()
	{
		mainMenuPanel.SetActive (false);
		howToPlayPanel.SetActive (true);
	}

	public void OpenSettingsPanel ()
	{
		mainMenuPanel.SetActive (false);
		settingsPanel.SetActive (true);
	}

	public void OpenHighScorePanel ()
	{
		mainMenuPanel.SetActive (false);
		highScorePanel.SetActive (true);
	}

	public void ReturnToMainMenu ()
	{
		ShowMainMenuPanel ();
	}

	public void StartLevel (string sceneName)
	{
		loadingText.text = "Loading...";

		Application.LoadLevel (sceneName);
	}

	private void ShowMainMenuPanel ()
	{
		mainMenuPanel.SetActive (true);
		
		selectLavelPanel.SetActive (false);
		howToPlayPanel.SetActive (false);
		settingsPanel.SetActive (false);
		highScorePanel.SetActive (false);
	}
}
