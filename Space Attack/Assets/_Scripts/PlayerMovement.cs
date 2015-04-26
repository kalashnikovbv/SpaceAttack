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
	public enum ControllType {joystick, tilt, keys};
	public ControllType controllType = 0;
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

		int controll = PlayerPrefs.GetInt ("ControlType");

		if (controll == 0)
		{
			controllType = ControllType.joystick;
		} 
		else if (controll == 1)
		{
			controllType = ControllType.tilt;
		} 
		else 
		{
			controllType = ControllType.keys;
		}
	}

	void FixedUpdate ()
	{
		if (controllType == ControllType.joystick) 
		{
			moveHorizontal = moveJoystick.position.x;
			moveVertical = moveJoystick.position.y;
		}
		else if (controllType == ControllType.tilt) 
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