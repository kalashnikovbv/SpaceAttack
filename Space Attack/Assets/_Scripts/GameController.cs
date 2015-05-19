using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour 
{	
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;

	public float spawnWait;
	public float startWait;
	public float waveWait;

	const string kHealth = "Health";
	const string kScore = "Score";
	
	public Text GameLabel;
	public Text HealthText;
	public Text ScoreText;

	int health = 100;
	int score = 0;
	int level = 1;

	int numberOfWaves = 10;
	bool levelIsRunning = true;
	bool spawningWaves = true;

	void Start ()
	{
//		Vector3 Size = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, 0, 0));	
//		spawnValues.x = Mathf.Floor (Size.x);

//		StartCoroutine (SpawnWaves ());

		health = 100;
		score = 0;

		PlayerPrefs.SetInt (kHealth, health);
		PlayerPrefs.SetInt (kScore, score);

		levelIsRunning = true;
		StartCoroutine ("SpawnWaves");

		GameLabel.text = "";
	}

	void Update ()
	{
		health = PlayerPrefs.GetInt (kHealth);
		score = PlayerPrefs.GetInt (kScore);

		HealthText.text = "Health: " + health;
		ScoreText.text = "Score: " + score;

		if (health == 0 && levelIsRunning) 
		{
			GameLabel.text = "Game Over";
			levelIsRunning = false;

			StopCoroutine ("SpawnWaves");

			StartCoroutine ("FinishLevel");
		}

		if (! spawningWaves && levelIsRunning)
		{
			GameLabel.text = "Well Done";
			levelIsRunning = false;

			int highScore = PlayerPrefs.GetInt ("Level" + level + "Score");

			if (score > highScore)
			{
				PlayerPrefs.SetInt ("Level" + level + "Score", score);
			}

			StartCoroutine ("FinishLevel");
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		spawningWaves = true;

		yield return new WaitForSeconds (startWait);

		for (int wave = 0; wave < numberOfWaves; wave++)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (waveWait);
		}

		spawningWaves = false;
	}

	void FadeOutLevelMusic ()
	{
		MusicController musicController = (MusicController) this.GetComponent (typeof (MusicController));
		musicController.FadeOutMusic ();
	}

	IEnumerator FinishLevel ()
	{
		this.FadeOutLevelMusic ();
		yield return new WaitForSeconds (5.0F);

		Application.LoadLevel ("MainMenu");
	}
}