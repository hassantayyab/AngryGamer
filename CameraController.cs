using UnityEngine;

public class CameraController : MonoBehaviour {

	public float HeightOffset = 60f;
	public float PlaneOffset = 10f;
	public float speed = 70f;

	private float m_TurnInputValue;     // The current value of the turn input.
	private string m_TurnAxisName;     	// The name of the input axis for turning.
  Transform m_camera;
	GameObject player;
	float step;

  void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		m_camera = GetComponent<Transform>();
  }

	void Start()
	{
		step = speed * Time.deltaTime;
	}

	void Update()
	{
		m_camera.position = new Vector3(player.transform.position.x, player.transform.position.y + HeightOffset, player.transform.position.z);

		if (player.transform.rotation.eulerAngles.y >= 150f && player.transform.rotation.eulerAngles.y <= 210f)
    {
      Quaternion rot = Quaternion.Euler(80f, 180f, 0f);
      m_camera.rotation = Quaternion.RotateTowards(m_camera.rotation, rot, step);
    }

		if (player.transform.rotation.eulerAngles.y <= 30f || player.transform.rotation.eulerAngles.y >= 330f)
    {
      Quaternion rot = Quaternion.Euler(80f, 0f, 0f);
      m_camera.rotation = Quaternion.RotateTowards(m_camera.rotation, rot, step);
    }

		if (player.transform.rotation.eulerAngles.y <= 120f && player.transform.rotation.eulerAngles.y >= 60f)
    {
      Quaternion rot = Quaternion.Euler(80f, 90f, 0f);
      m_camera.rotation = Quaternion.RotateTowards(m_camera.rotation, rot, step);
    }

    if (player.transform.rotation.eulerAngles.y >= 240f && player.transform.rotation.eulerAngles.y <= 300f)
    {
      Quaternion rot = Quaternion.Euler(80f, 270f, 0f);
      m_camera.rotation = Quaternion.RotateTowards(m_camera.rotation, rot, step);
    }
	}
}
