using UnityEngine;
using TMPro; // เพิ่มนี้!

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float currentScore = 0f;
    public int highScore = 0;

    public TMP_Text scoreText;        // เปลี่ยนจาก Text → TMP_Text
    public TMP_Text highScoreText;

    private bool isGameRunning = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        LoadHighScore();
    }

    void Update()
    {
        if (isGameRunning)
        {
            currentScore += Time.deltaTime;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + Mathf.FloorToInt(currentScore).ToString();

        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void PlayerDied()
    {
        isGameRunning = false;

        int finalScore = Mathf.FloorToInt(currentScore);
        if (finalScore > highScore)
        {
            highScore = finalScore;
            SaveHighScore();
        }

        currentScore = 0;
        UpdateUI();
    }

    void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
}
