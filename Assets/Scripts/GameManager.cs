using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField] private GameObject[] birdPrefabs;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<SpawnPipes>();
        highScoreText.text = PlayerPrefs.GetInt("High Score", 0).ToString();
        LoadBird();
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

        AudioListener.volume = 1f;
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
        RestartScene();
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
        if (score > PlayerPrefs.GetInt("High Score", 0))
        {
            PlayerPrefs.SetInt("High Score", score);
            highScoreText.text = score.ToString();
        }
    }

    private void LoadBird()
    {
        int birdIndex = PlayerPrefs.GetInt("BirdIndex");
        GameObject.Instantiate(birdPrefabs[birdIndex]);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
