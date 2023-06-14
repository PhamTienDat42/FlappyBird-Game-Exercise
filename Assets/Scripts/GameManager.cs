using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SpawnPipes spawner;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private GameObject highScore;
    [SerializeField] private GameObject highScoreLabelText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private AudioSource BGMusic;
    [SerializeField] private GameObject quitbtn;
    public int score { get; private set; }
    private const string highScores = "High Score";
    private const string birdIndexs = "BirdIndex";
    private const string saveIndexBird = "SaveIndexBird";
    [SerializeField] private GameObject[] birdPrefabs;
    private BirdDontDestroyOnLoad birdDontDestroyOnLoad;
    private GameObject objDontDestroyOnLoad;
    private int birdIndex;

    private void Start()
    {
        int myValue = PlayerPrefs.GetInt("SoundOn", 1);
        if (myValue == 0)
        {
            BGMusic.Pause();
        }
    }

    private void Awake()
    {
        objDontDestroyOnLoad = GameObject.FindGameObjectWithTag(saveIndexBird);
        birdDontDestroyOnLoad = objDontDestroyOnLoad.GetComponent<BirdDontDestroyOnLoad>();
        birdIndex = birdDontDestroyOnLoad.BirdIndex;
        Application.targetFrameRate = 60;
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
        quitbtn.SetActive(false);
        AudioListener.volume = 1f;
        Time.timeScale = 1f;

        PipesMovement[] pipes = FindObjectsOfType<PipesMovement>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene(SceneName.StartScene.ToString());
    }

    public void GameOver()
    {
        highScore.SetActive(true);
        highScoreLabelText.SetActive(true);
        playButton.SetActive(true);
        gameOver.SetActive(true);
        quitbtn.SetActive(true);
        Pause();
        RestartScene();
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
        birdPrefabs[birdIndex].SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
