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

	enum ControlType {joystick, tilt, keys};
	ControlType controlType = ControlType.joystick;

	int audioEnabled = 1;

	void Start ()
	{
		controlType = (ControlType) PlayerPrefs.GetInt ("ControlType");

		if (controlType == ControlType.joystick)
		{
			joystickToggle.isOn = true;
		} 
		else if (controlType == ControlType.tilt)
		{
			tiltToggle.isOn = true;
		} 
		else 
		{
			keysToggle.isOn = true;
		}

		float value = PlayerPrefs.GetFloat ("ControlSensitivity");

		if ((value > 0) && (value <= 10)) {
			controlSensitivitySlider.value = value;
		} else {
			value = 5.0F;

			controlSensitivitySlider.value = value;
			PlayerPrefs.SetFloat("ControlSensitivity", value);
		}

		int audioEnabled = PlayerPrefs.GetInt ("AudioEnabled");
		
		if (audioEnabled == 1)
		{
			audioToggle.isOn = true;
		}
		else
		{
			audioToggle.isOn = false;
		}
	}
	
	public void joystickToggleStateChanged ()
	{
		if ((joystickToggle.isOn) && (this.controlType != ControlType.joystick))
		{
			controlType = ControlType.joystick;

			tiltToggle.isOn = false;
			keysToggle.isOn = false;

			Debug.Log ("Joystick");

			PlayerPrefs.SetInt ("ControlType", (int) controlType);
		} 
		else if ((joystickToggle.isOn == false) && (this.controlType == ControlType.joystick))
		{
			joystickToggle.isOn = true;
		}

		return;
	}

	public void tiltToggleStateChanged ()
	{
		if ((tiltToggle.isOn) && (this.controlType != ControlType.tilt))
		{
			controlType = ControlType.tilt;

			joystickToggle.isOn = false;
			keysToggle.isOn = false;

			Debug.Log ("Tilt");
			
			PlayerPrefs.SetInt ("ControlType", (int) controlType);
		}
		else if ((tiltToggle.isOn == false) && (this.controlType == ControlType.tilt))
		{
			tiltToggle.isOn = true;
		}

		return;
	}

	public void keysToggleStateChanged ()
	{
		if ((keysToggle.isOn) && (this.controlType != ControlType.keys))
		{
			controlType = ControlType.keys;

			joystickToggle.isOn = false;
			tiltToggle.isOn = false;

			Debug.Log ("Keys");
			
			PlayerPrefs.SetInt ("ControlType", (int) controlType);
		}
		else if ((keysToggle.isOn == false) && (this.controlType == ControlType.keys))
		{
			keysToggle.isOn = true;
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
