using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{	
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;

	public float spawnWait;
	public float startWait;
	public float waveWait;

	int numberOfWaves = 5;
	const string kHealth = "Health";

	void Start ()
	{
//		Vector3 Size = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, 0, 0));	
//		spawnValues.x = Mathf.Floor (Size.x);

//		StartCoroutine (SpawnWaves ());
		StartCoroutine ("SpawnWaves");
	}

	void Update ()
	{
		int playerHealth = PlayerPrefs.GetInt (kHealth);

		if (playerHealth == 0) 
		{
			StopCoroutine ("SpawnWaves");

			StartCoroutine ("FinishLevel");
		}
	}
	
	IEnumerator SpawnWaves ()
	{
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
	}

	IEnumerator FinishLevel ()
	{
		yield return new WaitForSeconds (5.0F);
		Debug.Log ("Level Ended");
	}
}