using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdSelection : MonoBehaviour
{
    public GameObject[] Birds;
    private int birdIndex;

    public void ChangeBird(int index)
    {
        for(int i = 0; i < Birds.Length; i++)
        {
            Birds[i].SetActive(false);
        }
        this.birdIndex = index;
        Birds[index].SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("BirdIndex", birdIndex);
    }
}
