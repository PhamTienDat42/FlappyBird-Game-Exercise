using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDontDestroyOnLoad : MonoBehaviour
{
    private const string saveIndexBird = "SaveIndexBird";
    private int birdIndex;
    public int BirdIndex
    {
        get { return birdIndex; }
        set { birdIndex = value; }
    }

    private void Awake()
    {
        GameObject[] objDontDestroy = GameObject.FindGameObjectsWithTag(saveIndexBird);
        if (objDontDestroy.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
