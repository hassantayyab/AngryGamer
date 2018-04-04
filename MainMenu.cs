using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
	{
		Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(1);
	}

	public void QuitGame()
	{
		Debug.Log("Game Quit");
		Application.Quit();
	}
}
