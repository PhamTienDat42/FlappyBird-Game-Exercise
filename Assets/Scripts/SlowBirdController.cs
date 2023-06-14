using UnityEngine;

public class SlowBirdController : Player
{
    private bool isSlowed = false;
    private float originalTimeScale;

    private void Start()
    {
        originalTimeScale = Time.timeScale;
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!isSlowed)
            {
                SpecialSkill();
            }
            else if (isSlowed && Time.timeScale != originalTimeScale)
            {
                ResumeGame();
            }
        }
    }

    protected override void SpecialSkill()
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
