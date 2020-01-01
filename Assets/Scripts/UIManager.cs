using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject WaveUI;
    public TMP_Text WaveText;
    private string _waveString;
    public GameObject ScoreUI;
    public TMP_Text ScoreText;
    private string _scoreString;

    private int score = 0;

    void Start()
    {
        WaveText = WaveUI.GetComponent<TMP_Text>();
        ScoreText = ScoreUI.GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (WaveText != null && WaveText.text != _waveString)
        {
            WaveText.text = _waveString;
        }
        if (ScoreText != null && ScoreText.text != _scoreString)
        {
            ScoreText.text = _scoreString;
        }
    }

    public void SetWave(int waveNumber)
    {
        _waveString = "Wave: " + waveNumber;
    }

    public void IncrimentScore(int inc)
    {
        score += inc;
        _scoreString = "Score: " + score;
    }
}