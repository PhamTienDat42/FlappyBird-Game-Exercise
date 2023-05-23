using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Player player;
    private SpawnPipes spawner;

    public Text scoreText;
    public Text highScoreText;

    public GameObject highScore;
    public GameObject highScoreLabelText;
    public GameObject playButton;
    public GameObject gameOver;
    public int score { get; private set; }

    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("High Score", 0).ToString();
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<SpawnPipes>();

        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();

        highScore.SetActive(false);
        highScoreLabelText.SetActive(false);
        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        PipesMovement[] pipes = FindObjectsOfType<PipesMovement>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        highScore.SetActive(true);
        highScoreLabelText.SetActive(true);
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();       
        if(score > PlayerPrefs.GetInt("High Score", 0))
        {
            PlayerPrefs.SetInt("High Score", score);
            highScoreText.text = score.ToString();
        }
    }

}
