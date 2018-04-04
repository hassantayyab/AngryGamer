using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour {

	Text txt;
	public int score = 0;

	// Use this for initialization
	void Awake () {
		txt = GetComponent<Text>();

		if (SceneManager.GetActiveScene().buildIndex > 1)
            score = PlayerPrefs.GetInt("Score", score);

		txt.text = "Score: " + score.ToString();
	}
	
	public void ScoreUpdate() {
		score += 5;
		txt.text = "Score: " + score.ToString();

		if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            //Give the PlayerPrefs some values to send over to the next Scene
            PlayerPrefs.SetInt("Score", score);
        }
	}

	public void ScoreMinus() {
		score -= 2;
		txt.text = "Score: " + score.ToString();

		if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            //Give the PlayerPrefs some values to send over to the next Scene
            PlayerPrefs.SetInt("Score", score);
        }
	}
}
