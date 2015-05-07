using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsScript : MonoBehaviour 
{
	public Toggle joystickToggle;
	public Toggle tiltToggle;
	public Toggle keysToggle;

	public Toggle audioToggle;
	public Slider controlSensitivitySlider;

	enum ControllType {joystick, tilt, keys};
	ControllType controllType = ControllType.joystick;

	int audioEnabled = 1;

	void Start () {

	//	joystickToggle.isOn = true;
	//	tiltToggle.isOn = false;
	//	keysToggle.isOn = false;

	//	PlayerPrefs.SetInt ("ControlType", (int) controllType);
	//	PlayerPrefs.SetInt ("AudioEnabled", audioEnabled);

	//	PlayerPrefs.SetFloat ("ControlSensitivity", controlSensitivitySlider.value);

		int controlType = PlayerPrefs.GetInt ("ControlType");

		if (controlType == 0)
		{
			joystickToggle.isOn = true;
		} 
		else if (controlType == 1)
		{
			tiltToggle.isOn = true;
		} 
		else 
		{
			keysToggle.isOn = true;
		}

		float value = PlayerPrefs.GetFloat ("ControlSensitivity");
		controlSensitivitySlider.value = value;
	}
	
	public void joystickToggleStateChanged ()
	{
		if (joystickToggle.isOn)
		{
			controllType = ControllType.joystick;

			tiltToggle.isOn = false;
			keysToggle.isOn = false;

			Debug.Log ("Joystick");

			PlayerPrefs.SetInt ("ControlType", (int) controllType);
		} 

		return;
	}

	public void tiltToggleStateChanged ()
	{
		if (tiltToggle.isOn)
		{
			controllType = ControllType.tilt;

			joystickToggle.isOn = false;
			keysToggle.isOn = false;

			Debug.Log ("Tilt");
			
			PlayerPrefs.SetInt ("ControlType", (int) controllType);
		}

		return;
	}

	public void keysToggleStateChanged ()
	{
		if (keysToggle.isOn)
		{
			controllType = ControllType.keys;

			joystickToggle.isOn = false;
			tiltToggle.isOn = false;

			Debug.Log ("Keys");
			
			PlayerPrefs.SetInt ("ControlType", (int) controllType);
		}

		return;
	}

	public void controlSensitivityChanged ()
	{
		float value = controlSensitivitySlider.value;

		Debug.Log ("Control Sensitivity changed to " + value);

		PlayerPrefs.SetFloat ("ControlSensitivity", value);

		return;
	}

	public void audioToggleStateChanged ()
	{
		if (audioToggle.isOn)
		{
			audioEnabled = 1;
		}
		else 
		{
			audioEnabled = 0;
		}
		
		PlayerPrefs.SetInt ("AudioEnabled", audioEnabled);
	}
}
