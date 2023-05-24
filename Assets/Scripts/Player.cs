using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float strength = 5f;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource deathSound;    
    private const string obstacle = "Obstacle";
    private const string scoring = "Scoring";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        // Apply gravity and update the position
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime; 
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(obstacle))
        {
            deathSound.Play();
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.CompareTag(scoring))
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
