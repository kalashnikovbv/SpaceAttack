using UnityEngine;
using System.Collections;

public class SkyBoxRotation : MonoBehaviour 
{
	public Camera mainCamera;
	public Camera skyBoxCamera;

	public Vector3 skyRotation;

	// Use this for initialization
	void Start ()
	{
		if (skyBoxCamera.depth >= mainCamera.depth)
		{
			Debug.Log ("WARNING! MainCamera depth must be lower than SkyBoxCamera depth");
		}

		if (mainCamera.clearFlags != CameraClearFlags.Nothing)
		{
			Debug.Log ("WARNING! MainCamera's clearFlags must be set to nothing");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		skyBoxCamera.transform.Rotate(skyRotation);
	}
}
