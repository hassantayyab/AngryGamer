using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

	public CameraController cameraScript;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			cameraScript.enabled = false;
			FindObjectOfType<TimeScript>().end = true;
			// FindObjectOfType<GameManager>().score = levelScore;
			Invoke("LoadingLevel", 2f);
		}
	}

	void LoadingLevel()
	{
		FindObjectOfType<GameManager>().LoadLevel();
	}
}
