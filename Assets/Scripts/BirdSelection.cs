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

    public void ChangeBird(int index)
    {
        for(int i = 0; i < Birds.Length; i++)
        {
            Birds[i].SetActive(false);
            selectedBirdPrefab = true;
        }
        this.birdIndex = index;
        Birds[index].SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneName.FlappyBird.ToString());
        if (!selectedBirdPrefab)
        {
            Birds[0].SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt(birdIndexs, birdIndex);
        }
    }
}
