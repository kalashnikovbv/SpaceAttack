using UnityEngine;
using System.Collections;

public class EnemyBoltMovement : MonoBehaviour 
{
	public float speed = 10;
	
	void Start () {
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
