using UnityEngine;
using System.Collections;

public class EnemyBossController : MonoBehaviour
{
	public GameObject enemyDroid;
	public GameObject asteroid;
	public GameObject shot;

	public GameObject explosion;
	public GameObject shotExplosion;

	public Transform leftDroidCreator;
	public Transform rightDroidCreator;

	public Transform leftAsteroidCreator;
	public Transform rightAsteroidCreator;

	public Transform bossCannon;

	public GameController gameController;

	private float nextFire;
	private float fireRate;
	private bool droidCreate = true;

	private int health = 100;

	const string kScore = "Score";

	Vector3 pointA;
	Vector3 pointB;

	Vector3 explosionPosition;

	bool shoot = false;
	bool takeDamage = false;
	float movementTime = 5.0F;
	
	IEnumerator Start ()
	{
		pointA = new Vector3 (-2.5F, 0.0F, 15.0F);
		pointB = new Vector3 (2.5F, 0.0F, 15.0F);

		fireRate = 2.0F;

		yield return StartCoroutine (MoveObject (transform.position, pointA, movementTime));

		shoot = true;
		takeDamage = true;

		while (true)
		{
			yield return StartCoroutine (MoveObject (pointA, pointB, movementTime));
			yield return StartCoroutine (MoveObject (pointB, pointA, movementTime));
		}
	}

	void Update ()
	{
		if ((Time.time > nextFire) && shoot)
		{
			nextFire = Time.time + fireRate;
			
			if (droidCreate)
			{
				Instantiate (enemyDroid, leftDroidCreator.position, leftDroidCreator.rotation);
				Instantiate (enemyDroid, rightDroidCreator.position, rightDroidCreator.rotation);

				droidCreate = false;
			} else
			{	
				Instantiate (asteroid, leftAsteroidCreator.position, leftAsteroidCreator.rotation);
				Instantiate (asteroid, rightAsteroidCreator.position, rightAsteroidCreator.rotation);

				droidCreate = true;
			}

			Instantiate (shot, bossCannon.position, bossCannon.rotation);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary")
		{
			//Do nothing and return
			return;
		}
		else 
		{
			if (takeDamage)
			{
				explosionPosition.x = transform.position.x;
				explosionPosition.y = transform.position.y;
				explosionPosition.z = transform.position.z - 4.0F;

				Instantiate (shotExplosion, explosionPosition, transform.rotation);

				int currentScore = PlayerPrefs.GetInt (kScore);
				currentScore += 50;
				PlayerPrefs.SetInt (kScore, currentScore);

				health -= 1;
			}
		}

		if (health <= 0)
		{
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);

			gameController.EndSpawningWaves ();
		}
	}

	IEnumerator MoveObject(Vector3 start, Vector3 end, float time)
	{
		float i = 0.0f;
		float rate = 1.0f / time;
		
		while (i < 1.0f)
		{
			i += Time.deltaTime * rate;
			transform.position = Vector3.Lerp(start, end, i);
			
			yield return null; 
		}
	}
}
