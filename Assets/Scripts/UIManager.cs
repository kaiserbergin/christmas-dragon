using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject WaveUI;
    public TMP_Text WaveText;
    public GameObject ScoreUI;
    public TMP_Text ScoreText;

    private int score = 0;

    void Start()
    {
        WaveText = WaveUI.GetComponent<TMP_Text>();
        ScoreText = ScoreUI.GetComponent<TMP_Text>();
    }

    public void SetWave(int waveNumber)
    {
        WaveText.text = "Wave: " + waveNumber;
    }

    public void IncrimentScore(int inc)
    {
        score += inc;
        ScoreText.text = "Score: " + score;
    }
}