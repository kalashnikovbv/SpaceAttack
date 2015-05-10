using UnityEngine;
using System.Collections;

public class AudioSwitch : MonoBehaviour
{
	void Start ()
	{
		int musicEnabled = PlayerPrefs.GetInt ("AudioEnabled");
		
		if (musicEnabled == 1)
		{
			GetComponent<AudioSource> ().Play();
		}
	}
}