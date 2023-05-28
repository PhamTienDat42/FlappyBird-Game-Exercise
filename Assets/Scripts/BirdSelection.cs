using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] Birds;
    private int birdIndex;
    private bool selectedBirdPrefab = false;
    private const string birdIndexs = "BirdIndex";
    private Vector3 birdPosition;

    public void ChangeBird(int index)
    {
        for (int i = 0; i < Birds.Length; i++)
        {
            Birds[i].SetActive(false);
            selectedBirdPrefab = true;
        }
        this.birdIndex = index;
        Birds[index].SetActive(true);
        birdPosition = Birds[index].transform.position;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneName.FlappyBird.ToString());
        if (!selectedBirdPrefab)
        {
            Birds[0].SetActive(true);
            birdPosition = Birds[0].transform.position;
        }
        else
        {
            PlayerPrefs.SetInt(birdIndexs, birdIndex);
        }
    }

    public Vector3 GetSelectedBirdPosition()
    {
        return birdPosition;
    }
}
