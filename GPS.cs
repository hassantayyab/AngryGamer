using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour {

	public GameObject gps;
	public Sprite[] sprites;
	public Animator anim;

	Image img;

	// Use this for initialization
	void Start () {
		img = gps.GetComponent<Image>();
  }

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (gameObject.name == "d0")
				img.sprite = sprites[0];
			else if (gameObject.name == "d1")
				img.sprite = sprites[1];
			else if (gameObject.name == "d2")
				img.sprite = sprites[2];
			else if (gameObject.name == "d3")
				img.sprite = sprites[3];

			gps.SetActive(true);
			anim.SetBool("activate", true);
			Invoke("Disable", 1.5f);
		}
	}
	
	void Disable()
	{
		gps.SetActive(false);
        anim.SetBool("activate", false);
    }
}
