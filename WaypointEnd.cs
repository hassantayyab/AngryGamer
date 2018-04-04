using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointEnd : MonoBehaviour {

	public GameObject obj;

	void OnTriggerEnter(Collider other)
	{
		// Debug.Log("Triggered!");	

        if (other.tag == "AI")
		{
			// Debug.Log("Entered");
			obj.SetActive(false);
		}
	}
}
