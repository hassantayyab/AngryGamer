using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		player.SetActive(false);
	}
}
