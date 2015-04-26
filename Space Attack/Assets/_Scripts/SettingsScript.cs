using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsScript : MonoBehaviour 
{
	public Toggle joystickToggle;
	public Toggle tiltToggle;
	public Toggle audioToggle;

	enum ControllType {joystick, tilt, keys};
	ControllType controllType = ControllType.joystick;

	int audioEnabled = 1;

	void Start () {

		joystickToggle.isOn = true;
		tiltToggle.isOn = false;

		PlayerPrefs.SetInt ("ControlType", (int) controllType);
		PlayerPrefs.SetInt ("AudioEnabled", audioEnabled);
	}
	
	public void joystickToggleStateChanged ()
	{
		if (joystickToggle.isOn)
		{
			controllType = ControllType.joystick;
			tiltToggle.isOn = false;
		}
		else 
		{
			controllType = ControllType.tilt;
			tiltToggle.isOn = true;
		}

		PlayerPrefs.SetInt ("ControlType", (int) controllType);
	}

	public void tiltToggleStateChanged ()
	{
		if (tiltToggle.isOn)
		{
			controllType = ControllType.tilt;
			joystickToggle.isOn = false;
		}
		else 
		{
			controllType = ControllType.joystick;
			joystickToggle.isOn = true;
		}
		
		PlayerPrefs.SetInt ("ControlType", (int) controllType);
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
