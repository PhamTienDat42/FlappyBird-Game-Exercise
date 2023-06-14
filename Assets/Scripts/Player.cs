using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float strength = 5f;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private float pipeWidth = 1f; // width
    [SerializeField] private float spacePipe = 2f; // space between top-bottom pipe
    private List<GameObject> scoredPipes = new List<GameObject>();
    [SerializeField] private SpawnPipes spawnPipes;
    [SerializeField] private GameManager gameManager;



    protected abstract void SpecialSkill();

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }
        // Apply gravity and update the position
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        CheckCollisionWithPipes();
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    
    private void CheckCollisionWithPipes()
    {
        Vector3 playerPosition = transform.position;
        Vector3 nextPipePosition = spawnPipes.GetNextPipePosition();
        GameObject nextPipe = spawnPipes.GetGameObjectNextPipe();
        

        float collisionXMin = nextPipePosition.x - pipeWidth / 2f;
        float collisionXMax = nextPipePosition.x + pipeWidth / 2f;
        float collisionYMin = nextPipePosition.y - spacePipe / 2f;
        float collisionYMax = nextPipePosition.y + spacePipe / 2f;

        // Check Collision
        if ((playerPosition.x > collisionXMin && playerPosition.x < collisionXMax &&
            (playerPosition.y > collisionYMax || playerPosition.y < collisionYMin)) || playerPosition.y < -4.5f || playerPosition.y > 5.5f)
        {
            deathSound.Play();
            gameManager.GameOver();
        }
        else if (!scoredPipes.Contains(nextPipe) && playerPosition.x > collisionXMin && playerPosition.x < collisionXMax &&
            (playerPosition.y < collisionYMax || playerPosition.y > collisionYMin))
        {
            scoredPipes.Add(nextPipe);
            gameManager.IncreaseScore();
        }
    }
}

