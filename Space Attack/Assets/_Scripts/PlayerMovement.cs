using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin = -1;
	public float xMax = 1;
	public float zMin = -1;
	public float zMax = 1;
}

public class PlayerMovement : MonoBehaviour
{
	public enum ControlType {joystick, tilt, keys};
	public ControlType controlType = 0;
	public Joystick moveJoystick;

	public float speed = 10;
	public float tilt = 1;
	public Boundary boundary;

	private float moveHorizontal = 0.0f;
	private float moveVertical = 0.0f;

	void Start () 
	{
//		Vector3 Size = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, 0, 0));

//		float width = Mathf.Floor (Size.x);

//		boundary.xMin = 0 - width;
//		boundary.xMax = 0 + width;

//		Debug.Log ("Screen size: " + Size.x + "x" + Size.y);

		int control = PlayerPrefs.GetInt ("ControlType");
		float controlSensitivity = PlayerPrefs.GetFloat ("ControlSensitivity");

		if (control == 0)
		{
			controlType = ControlType.joystick;
			speed = controlSensitivity * 2;
		} 
		else if (control == 1)
		{
			controlType = ControlType.tilt;
			speed = controlSensitivity * 3;
		} 
		else 
		{
			controlType = ControlType.keys;
			speed = controlSensitivity * 2;
		}
	}

	void FixedUpdate ()
	{
		if (controlType == ControlType.joystick) 
		{
			moveHorizontal = moveJoystick.position.x;
			moveVertical = moveJoystick.position.y;
		}
		else if (controlType == ControlType.tilt) 
		{
			moveJoystick.Disable();
			moveHorizontal = Input.acceleration.x;
			moveVertical = Input.acceleration.y+0.5f;
		}
		else 
		{
			moveJoystick.Disable();
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");
		}

		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
			);

		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}