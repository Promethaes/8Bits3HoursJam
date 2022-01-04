using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float currentScore = 0.0f;
    public float highscore = 0.0f;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI highscoreText;


    static ScoreManager _instance = null;

    private void OnEnable()
    {
        if (_instance != null)
            gameObject.SetActive(false);
        _instance = this;
        highscore = PlayerPrefs.GetFloat("hs", 0.0f);
        _instance.highscoreText.text = "High Score: " + _instance.highscore.ToString();
    }

    public void SaveScore()
    {
        if (currentScore > highscore)
            PlayerPrefs.SetFloat("hs", currentScore);
    }

    public static void AddScore(float s)
    {
        _instance.currentScore += s;
        _instance.scoreText.text = "Score: " + _instance.currentScore.ToString();
        if (_instance.currentScore > _instance.highscore)
            _instance.highscoreText.text = "High Score: " + _instance.highscore.ToString();
    }

    private void OnDisable()
    {
        SaveScore();
        _instance = null;
    }
}
