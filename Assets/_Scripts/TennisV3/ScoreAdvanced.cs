using System;
using TMPro;
using UnityEngine;

namespace _Scripts.TennisV3
{
    public class ScoreAdvanced : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;

        private void Awake()
        {
            scoreText = GetComponent<TMP_Text>();
        }

        private void SetScore(int playerScore, int aiScore)
        {
            scoreText.text = $"{playerScore} - {aiScore}"; // esto es para no tener que poner algo + algo + ...
        }

        private void OnEnable()
        {
            GameManagerAdvanced.Instance.OnResetScore += SetScore;
            GameManagerAdvanced.Instance.OnAIScore += SetScore;
            GameManagerAdvanced.Instance.OnPlayerScore += SetScore;
        }

        private void OnDisable()
        {
            GameManagerAdvanced.Instance.OnResetScore -= SetScore;
            GameManagerAdvanced.Instance.OnAIScore -= SetScore;
            GameManagerAdvanced.Instance.OnPlayerScore -= SetScore;
        }
    }
}