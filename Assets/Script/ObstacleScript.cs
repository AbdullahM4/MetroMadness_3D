using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    // Audio clip for collision sound
    public AudioClip collisionSound;

    // Reference to the AudioSource component
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the obstacle GameObject
        audioSource = GetComponent<AudioSource>();

        // Assign the collision sound clip to the AudioSource
        audioSource.clip = collisionSound;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Play the collision sound
            audioSource.Play();
        }
    }
}
