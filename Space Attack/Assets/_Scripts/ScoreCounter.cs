using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCounter : MonoBehaviour
{
	private int score;
	Text scoreText;

	const string kScore = "Score";
	
	void Start ()
	{
		scoreText = GetComponent<Text> ();

		score = 0;
		PlayerPrefs.SetInt (kScore, score);
	}

	void Update ()
	{
		score = PlayerPrefs.GetInt (kScore);
		scoreText.text = "Score: " + score;
	}
}
