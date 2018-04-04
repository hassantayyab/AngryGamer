using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour {

	// public GameObject timeout;

    Text txt;

	// Use this for initialization
	void Awake () {
		// timeout.SetActive(false);
        txt = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Start () {
		int level = SceneManager.GetActiveScene().buildIndex;
		// Debug.Log(level);
        txt.text = "Level " + (level).ToString();
	}
}
