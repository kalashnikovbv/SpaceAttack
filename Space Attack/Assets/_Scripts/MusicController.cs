using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour 
{
	enum Fade {In, Out};
	float fadeTime = 10.0F;
	
	void Start ()
	{
		StartCoroutine (FadeAudio (fadeTime, Fade.In));
	}
	
	void Update ()
	{
		int musicEnabled = PlayerPrefs.GetInt ("AudioEnabled");
		
		if (musicEnabled == 1) 
		{
			GetComponent<AudioSource> ().mute = false;
		} 
		else 
		{
			GetComponent<AudioSource> ().mute = true;
		}
	}
	
	public void FadeOutMusic ()
	{
		StartCoroutine(FadeAudio(4.0F, Fade.Out));
	}

	IEnumerator FadeAudio (float timer, Fade fadeType)
	{
		Debug.Log ("FadeAudio");
		float start = (fadeType == Fade.In) ? 0.0F : 0.5F;
		float end = (fadeType == Fade.In) ? 0.5F : 0.0F;
		float i = 0.0F;
		float step = 1.0F / timer;
		
		while (i <= 1.0F)
		{
			i += step * Time.deltaTime;
			
			GetComponent<AudioSource> ().volume = Mathf.Lerp(start, end, i);
			yield return new WaitForSeconds(step * Time.deltaTime);
		}
	}
}