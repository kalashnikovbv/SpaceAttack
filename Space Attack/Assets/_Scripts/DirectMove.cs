using UnityEngine;
using System.Collections;

public class DirectMove : MonoBehaviour 
{
	public float moveSpeed = 10;

	void Start ()
	{
		GetComponent<Rigidbody>().velocity = -transform.forward * moveSpeed;
	}
}
