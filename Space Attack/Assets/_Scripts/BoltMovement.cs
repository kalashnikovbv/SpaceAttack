using UnityEngine;
using System.Collections;

public class BoltMovement : MonoBehaviour {

	public float speed = 10;

	void Start () {
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}