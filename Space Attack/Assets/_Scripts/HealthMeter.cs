using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthMeter : MonoBehaviour
{
	private int health;
	Text healthText;
	
	const string kHealth = "Health";
	
	void Start ()
	{
		healthText = GetComponent<Text> ();

		health = 100;
		PlayerPrefs.SetInt (kHealth, health);
	}
	
	void Update ()
	{
		health = PlayerPrefs.GetInt (kHealth);
		healthText.text = "Health: " + health;
	}
}
