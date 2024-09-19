using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;

    public Mybutton gasPedal;
    public Mybutton breakPedal;

    // The threshold below which the level will be reset
    private float fallThreshold = -5.0f;

    // Reference to the joystick
    public Joystick movementJoystick;

    // Rigidbody component for physics-based movement
    private Rigidbody rb;

    public AudioClip gasSound;
    public AudioClip revSound;
    public AudioClip idleSound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        PlayIdleSound();
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input from the joystick
        horizontalInput = movementJoystick.Horizontal;

        // Determine forward input based on gas and brake pedals
        if (gasPedal.isPressed)
        {
            forwardInput = 1.0f; // Move forward when gas pedal is pressed
            PlayGasSound();
        }
        else if (breakPedal.isPressed)
        {
            forwardInput = -1.0f; // Move backward when brake pedal is pressed
            PlayRevSound();
        }
        else
        {
            forwardInput = 0.0f; // No movement when neither pedal is pressed
            PlayIdleSound();
        }

        // Check if the vehicle has fallen below the fall threshold
        if (transform.position.y < fallThreshold)
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // FixedUpdate is called at a fixed interval and is used for physics calculations
    void FixedUpdate()
    {
        // Move the vehicle forward or backward
        Vector3 forwardMove = transform.forward * forwardInput * speed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMove);

        // Turn the vehicle
        float turn = horizontalInput * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with has the tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void PlayGasSound()
    {
        if (audioSource.clip != gasSound)
        {
            audioSource.clip = gasSound;
            audioSource.Play();
        }
    }

    private void PlayRevSound()
    {
        if (audioSource.clip != revSound)
        {
            audioSource.clip = revSound;
            audioSource.Play();
        }
    }

    private void PlayIdleSound()
    {
        if (audioSource.clip != idleSound)
        {
            audioSource.clip = idleSound;
            audioSource.Play();
        }
    }
}
