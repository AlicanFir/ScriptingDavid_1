using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private int _playerScore = 0, _aiScore = 0;

    [SerializeField] private int maxScore = 2;

    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
        ResetScore();
    }

    public void ResetScore()
    {
        _playerScore = _aiScore = 0;
        SetScore();
    }

    private void SetScore()
    {
        scoreText.text = $"{_playerScore} - {_aiScore}"; // esto es para no tener que poner algo + algo + ...
    }

    public void AddPlayerScore()
    {
        _playerScore++;
        SetScore();
    }

    public void AddAIScore()
    {
        _aiScore++;
        SetScore();
    }

    public bool IsFinished()
    {
        return (_playerScore > maxScore || _aiScore > maxScore);
    }
}
