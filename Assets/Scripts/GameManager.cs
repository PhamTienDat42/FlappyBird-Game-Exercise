using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IGameManager
{
    [SerializeField] private SpawnPipes spawner;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;

    [SerializeField] private GameObject highScore;
    [SerializeField] private GameObject highScoreLabelText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;
    public int score { get; private set; }
    private const string highScores = "High Score";
    private const string birdIndexs = "BirdIndex";

    [SerializeField] private GameObject[] birdPrefabs;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        //spawner = FindObjectOfType<SpawnPipes>();
        highScoreText.text = PlayerPrefs.GetInt(highScores, 0).ToString();
        LoadBird();
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = $"Score: {score.ToString()}";
        highScore.SetActive(false);
        highScoreLabelText.SetActive(false);
        playButton.SetActive(false);
        gameOver.SetActive(false);
        AudioListener.volume = 1f;
        Time.timeScale = 1f;
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
        Invoke("RestartScene", 0.1f);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = $"Score: {score.ToString()}";
        if (score > PlayerPrefs.GetInt(highScores, 0))
        {
            PlayerPrefs.SetInt(highScores, score);
            highScoreText.text = score.ToString();
        }
    }

    private void LoadBird()
    {
        int birdIndex = PlayerPrefs.GetInt(birdIndexs);
        GameObject.Instantiate(birdPrefabs[birdIndex]);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

public interface IGameManager
{
    void GameOver();
    void IncreaseScore();
}