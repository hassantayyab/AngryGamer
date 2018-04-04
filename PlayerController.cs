using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float m_Speed = 29f;			// How fast the tank moves forward and back.
    public float m_TurnSpeed = 180f;	// How fast the tank player in degrees per second.
    public float m_PitchRange = 0.2f;   // The amount by which the pitch of the engine noises can vary.
    public float acceleration = 0f;
    public float reverseSpeed = 5f;
    public float forwardSpeed = 5f;
    public Vector3 force = new Vector3(0f, 0f, 0f);
    public float health = 50f;
    public float damage = 10f;
    public Scoring sc;
    public AudioSource explosionSound;
    public AudioSource CarHitSound;
    public AudioSource CarSound;
    public AudioSource ScoringSound;
    public AudioClip AccelerationClip;
    public AudioClip IdleClip;
    public Transform m_explosion;
    public ParticleSystem[] particles;

    private string m_MovementAxisName;  // The name of the input axis for moving forward and back.
    private string m_TurnAxisName;      // The name of the input axis for turning.
    private Rigidbody m_Rigidbody;      // Reference used to move the player.
    private float m_MovementInputValue; // The current value of the movement input.
    private float m_TurnInputValue;     // The current value of the turn input.
    private float m_OriginalPitch;      // The pitch of the audio source at the start of the scene.
    float elapsedTime;


    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // The axes names are based on player number.
        elapsedTime = 5f;
        m_MovementAxisName = "Vertical";
        m_TurnAxisName = "Horizontal";

        // Store the original pitch of the audio source.
        m_OriginalPitch = CarSound.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        // Store the value of both input axes.
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);

        EngineAudio();
    }

    void EngineAudio()
    {
        // If there is no input (the tank is stationary)...
        if (Mathf.Abs(m_MovementInputValue) < 0.1f)
        {
            if (acceleration < m_Speed)
            {
                if (CarSound.clip == IdleClip)
                {
                    CarSound.clip = AccelerationClip;
                    CarSound.pitch = Random.Range(1.3f - 0.1f, 1.3f + 0.1f);
                    CarSound.Play();
                }
            }
            else
            {
                if (CarSound.clip == AccelerationClip)
                {
                    // CarSound.pitch = Random.Range(1.2f - 0.1f, 1.2f + 0.1f);
                    // CarSound.clip = IdleClip;
                    CarSound.pitch = Random.Range(1.3f - 0.1f, 1.3f + 0.1f);
                    // CarSound.Play();
                }   
            }
        }
        else
        {
            // Otherwise if the tank is moving and if the idling clip is currently playing...
            if (CarSound.clip == IdleClip)
            {
                // ... change the clip to driving and play.
                CarSound.clip = AccelerationClip;
                CarSound.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                CarSound.Play();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collect")
        {
            // Debug.Log("Should Play!");
            ScoringSound.Play();
        }
    }

    void OnCollisionExit(Collision other)
    {
        m_explosion.position = gameObject.transform.position;

        if (other.gameObject.tag != "Ignore")
        {
            CarHitSound.Play();

            sc.ScoreMinus();

            health -= damage;
            FindObjectOfType<HealthBar>().Damage(damage);

            if (health <= 0f)
            {
                explosionSound.Play();

                foreach (ParticleSystem particle in particles)
                {
                    particle.Play();
                }

                gameObject.SetActive(false);
                FindObjectOfType<GameManager>().RestartOnExplosion();
            }
        }
    }

    private void FixedUpdate()
    {
        // reset car if it tilts
        if (transform.rotation.x > 0f || transform.rotation.z > 0f)
        {
            elapsedTime -= Time.deltaTime;
            if (elapsedTime <= 0f)
            {
                // Make this into a rotation in the y axis.
                Quaternion turnRotation = Quaternion.Euler(0f, m_Rigidbody.rotation.y, 0f);

                // Apply this rotation to the rigidbody's rotation.
                m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
            }
        }
        elapsedTime = 3f;

        // Adjust the rigidbodies position and orientation in FixedUpdate.
        Move();
        Turn();
    }

    private void Move()
    {
        // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * acceleration * Time.deltaTime;

        // bool acc = false;

        if (Input.GetKey(KeyCode.W))
        {
            m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
            // Vector3 mov = transform.forward * m_MovementInputValue * (reverseSpeed  ) * Time.deltaTime;
            movement += transform.forward * (forwardSpeed) * Time.deltaTime;
            // m_Rigidbody.MovePosition(m_Rigidbody.position + mov);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
            // Vector3 mov = transform.forward * m_MovementInputValue * (reverseSpeed  ) * Time.deltaTime;
            movement -= transform.forward * reverseSpeed * Time.deltaTime;
            // m_Rigidbody.MovePosition(m_Rigidbody.position + mov);
        }

        // Apply this movement to the rigidbody's position.
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);

        if (acceleration < m_Speed)
        {
            acceleration += 0.5f;
        }
    }

    private void Turn()
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }
}
