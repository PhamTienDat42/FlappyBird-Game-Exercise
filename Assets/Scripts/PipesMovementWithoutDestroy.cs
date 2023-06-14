using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesMovementWithoutDestroy : MonoBehaviour
{
    [SerializeField] private Transform top;
    [SerializeField] private Transform bottom;

    [SerializeField] private float speed = 5f;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            gameObject.SetActive(false);
            transform.position = new Vector3(12, 0, 0);
            gameObject.SetActive(true);
        }
    }
}
