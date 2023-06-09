using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipesWithoutDestroy : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float minHeight = -1f;
    [SerializeField] private float maxHeight = 2f;
    [SerializeField] private Transform transformPipes;
    private List<GameObject> spawnedPipes = new List<GameObject>();
    //private GameObject[] pipesArray;
    private int currentIndex = 0;
    //private int pipeCount = 0;


    private void Awake()
    {
        //pipesArray = new GameObject[4];    
        Spawn();
    }

    //private void OnEnable()
    //{
    //    InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    //}

    //private void OnDisable()
    //{
    //    CancelInvoke(nameof(Spawn));
    //}

    private void Spawn()
    {
        //GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        //pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

        //spawnedPipes.Add(pipes);

        //pipesArray[pipeCount] = pipes;
        //if (pipeCount >= 15)
        //{
        //    CancelInvoke(nameof(Spawn));
        //    return;
        //}

        //// Spawn pipe and add

        //pipeCount++;
        GameObject pipes = ObjectPool.SharedInstance.GetPooledObject();
        if(pipes != null)
        {
            pipes.transform.position = transformPipes.position;
            pipes.transform.rotation = transformPipes.rotation;
        }
    }

    public Vector3 GetNextPipePosition()
    {
        if (currentIndex < spawnedPipes.Count)
        {
            GameObject currentPipe = spawnedPipes[currentIndex];
            if (currentPipe != null)
            {
                return currentPipe.transform.position;
            }
            else
            {
                spawnedPipes.RemoveAt(currentIndex);
            }
        }
        return new Vector3(1000f, 1000f, 1000f);
    }

    public GameObject GetGameObjectNextPipe()
    {
        if (currentIndex < spawnedPipes.Count)
        {
            GameObject currentPipe = spawnedPipes[currentIndex];
            if (currentPipe != null)
            {
                return currentPipe;
            }
            else
            {
                spawnedPipes.RemoveAt(currentIndex);
            }
        }
        return null;
    }

    public void IncrementIndex()
    {
        currentIndex++;
    }
}
