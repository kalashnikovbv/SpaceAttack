using UnityEngine;
using System.Collections;

public class MainMenuNavigatior : MonoBehaviour
{
	public GameObject mainMenuPanel;
	public GameObject selectLavelPanel;
	public GameObject howToPlayPanel;
	public GameObject settingsPanel;

	void Start ()
	{
		mainMenuPanel.SetActive (true);
		selectLavelPanel.SetActive (false);
		howToPlayPanel.SetActive (false);
		settingsPanel.SetActive (false);

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

	public void ReturnToMainMenu ()
	{
		mainMenuPanel.SetActive (true);
		selectLavelPanel.SetActive (false);
		howToPlayPanel.SetActive (false);
		settingsPanel.SetActive (false);
	}

	public void StartLevel (string sceneName)
	{
		Application.LoadLevel (sceneName);
	}
}
