using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int score = 10;

	const string kScore = "Score";
	const string kHealth = "Health";

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			//Do nothing and return
			return;
		}
		else if (other.tag == "Player")
		{
			Instantiate (explosion, transform.position, transform.rotation);

			PlayerDamage (other);
			Destroy (gameObject);
		} 
		else if ((other.tag == "EnemyShot") || (other.tag == "EnemyDroid"))
		{
			//No friendly fire
		} 
		else 
		{
			Instantiate (explosion, transform.position, transform.rotation);

			int currentScore = PlayerPrefs.GetInt (kScore);
			currentScore += score;
			PlayerPrefs.SetInt (kScore, currentScore);

			Destroy (gameObject);
		}
	}

	void PlayerDamage (Collider player)
	{
		int damage = Random.Range (20, 40);

		int currentHealth = PlayerPrefs.GetInt (kHealth);

		if (currentHealth > damage) {
			currentHealth -= damage;
		} 
		else
		{
			Debug.Log ("Player's ship is destroyed");

			currentHealth = 0;

			Destroy(player.gameObject);
			Instantiate (playerExplosion, player.transform.position, player.transform.rotation);
		}

		PlayerPrefs.SetInt (kHealth, currentHealth);
	}
}
