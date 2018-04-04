using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour {

	public float time = 20;
	public GameObject timeout;
	public bool end = false;

	float timer;
    Text txt;
	bool again = false;

	void Awake()
	{
		timer = time + 3;
	}

	// Use this for initialization
	void Start () {
		txt = GetComponent<Text>();

		txt.text = "Time: " + time.ToString("0");
	}
	
	// Update is called once per frame
	void Update () {
		timer -= 1 * Time.deltaTime;
		if (timer <= time && timer > 0)
		{
			txt.text = "Time: " + timer.ToString("0");
		}
		else if (timer <= 0) {
			txt.text = "Time: 0";

			if (!again && !end)
			{
				again = true;
				timeout.SetActive(again);
				again = false;

				Invoke("Restart", 1f);
			}
        }
	}

	void Restart()
	{
		// timeout.SetActive(again);
		FindObjectOfType<GameManager>().RestartLevel();
	}
}
