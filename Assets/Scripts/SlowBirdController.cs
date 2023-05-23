using UnityEngine;

public class SlowBirdController : MonoBehaviour
{
    private bool isSlowed = false;
    private float originalTimeScale;

    private void Start()
    {
        originalTimeScale = Time.timeScale;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!isSlowed)
            {
                SlowGame();
            }
            else if (isSlowed && Time.timeScale != originalTimeScale)
            {
                ResumeGame();
            }
        }
    }


    private void SlowGame()
    {
        isSlowed = true;
        Time.timeScale = 0.5f;
    }

    private void ResumeGame()
    {
        isSlowed = false;
        Time.timeScale = 1f;
    }
}
