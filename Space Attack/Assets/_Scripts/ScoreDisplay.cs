using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour
{
	public Text level1Score;
	public Text level2Score;
	public Text level3Score;

	void Start ()
	{
		level1Score.text = "" + PlayerPrefs.GetInt ("Level1Score");
		level2Score.text = "" + PlayerPrefs.GetInt ("Level2Score");
		level3Score.text = "" + PlayerPrefs.GetInt ("Level3Score");
	}	
}
