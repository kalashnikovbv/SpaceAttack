using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour 
{
	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate = 0.5f;
	private float nextFire;
	
	void Update ()
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

			GetComponent<AudioSource>().Play();
		}
	}
}
