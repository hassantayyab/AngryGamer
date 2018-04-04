using UnityEngine;
using UnityEngine.Collections;
using UnityEngine.UI;

public class CountScript : MonoBehaviour {

	float counter = 4;
	Text txt;

	public PlayerController carScript;
	// Use this for initialization
	void Awake () {
		txt = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (counter < 1f) {
			txt.text = "GO!";
			carScript.enabled = true;
		} else {
			counter -= 1 * Time.deltaTime;
			if (counter <= 3)
			{
				txt.text = counter.ToString("0");
			}
		}
	}
}
