using UnityEngine;
using System.Collections;

public class DirectMove : MonoBehaviour 
{
	public enum Direction {forward, backward};
	public Direction direction = 0;
	public float moveSpeed = 10;

	Vector3 directionVector;

	void Start ()
	{
		if (direction == Direction.forward)
		{
			directionVector = Vector3.back;
		}
		else
		{
			directionVector = Vector3.forward;
		}

		GetComponent<Rigidbody>().velocity = directionVector * moveSpeed;
	}
}
