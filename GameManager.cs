using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject Dead;

	public int score = 0;

	public void LoadLevel()
	{
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.buildIndex + 1);
	}

	public void RestartOnExplosion()
	{
		Dead.SetActive(true);
		Invoke("RestartLevel", 3f);
	}

	public void RestartLevel()
	{
		Scene scene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(scene.buildIndex);
	}
}
