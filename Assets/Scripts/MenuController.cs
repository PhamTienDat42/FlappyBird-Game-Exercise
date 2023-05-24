using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneName.FlappyBird.ToString());
    }
    public void Quit()
    {
        Debug.Log("QUit!!!!");
        Application.Quit();
    }
}

public enum SceneName
{
    StartScene,
    FlappyBird,
}