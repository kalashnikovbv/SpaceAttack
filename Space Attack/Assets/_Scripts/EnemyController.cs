using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public GameObject shot;
	public Transform leftCannon;
	public Transform rightCannon;
	
	public float fireRate = 1.0f;

	private float nextFire;
	private bool leftCannonShoot = true;
	
	void Update ()
	{
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;

			if (leftCannonShoot)
			{
				Instantiate (shot, leftCannon.position, leftCannon.rotation);
				leftCannonShoot = false;
			} else
			{	
				Instantiate (shot, rightCannon.position, rightCannon.rotation);
				leftCannonShoot = true;
			}

			int audioEnabled = PlayerPrefs.GetInt("AudioEnabled");
			
			if (audioEnabled == 1)
			{
				GetComponent<AudioSource>().Play();
			}
		}
	}
}
