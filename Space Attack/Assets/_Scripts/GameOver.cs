using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour
{
	const string kHealth = "Health";

	Text gameOverText;

	void Start () 
	{
		gameOverText = GetComponent<Text> ();

		gameOverText.text = "";
	}
	
	// Update is called once per frame
	void Update () 
	{
		int health = PlayerPrefs.GetInt (kHealth);

		if (health <= 0)
		{
			gameOverText.text = "Game Over";
		}
	}
}
