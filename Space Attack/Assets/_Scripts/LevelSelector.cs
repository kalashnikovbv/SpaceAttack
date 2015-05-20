using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelector : MonoBehaviour
{
	public Button level2Button;
	public Button level3Button;

	void Start ()
	{
		if (PlayerPrefs.GetInt ("Level1Score") > 0)
		{
			level2Button.interactable = true;
		} else
		{
			level2Button.interactable = false;
		}

		if (PlayerPrefs.GetInt ("Level2Score") > 0)
		{
			level3Button.interactable = true;
		} else
		{
			level3Button.interactable = false;
		}
	}
}
