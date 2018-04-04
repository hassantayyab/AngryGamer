using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastLevel : MonoBehaviour
{

    public CameraController cameraScript;
    public GameObject end;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cameraScript.enabled = false;
            FindObjectOfType<TimeScript>().end = true;

			Invoke("Exit", 1f);
        }
    }

	void Exit()
	{
		end.SetActive(true);
	}
}
