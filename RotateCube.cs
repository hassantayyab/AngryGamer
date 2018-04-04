using UnityEngine;

[RequireComponent(typeof(Scoring))]
public class RotateCube : MonoBehaviour {

	public float speed = 10f;
	public Scoring sc;
	// public GameManager gm;
	// public Text txt;

	Transform cube;
	// int score = 0;

    // Use this for initialization
    void Start () {
		cube = GetComponent<Transform>();
		// sc = GetComponent<Scoring>();
		// txt.text = "Score " + score.ToString();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		cube.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			sc.ScoreUpdate();
      gameObject.SetActive(false);
		}
	}
}
