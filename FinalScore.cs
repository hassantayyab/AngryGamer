using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalScore : MonoBehaviour {

	TextMeshProUGUI txt;

    public Scoring sc;

	// Use this for initialization
	void Awake()
	{
		txt = GetComponent<TextMeshProUGUI>();
	}

	void Update () {
		Debug.Log(sc.score);
		
		txt.text = sc.score.ToString();
	}

}
