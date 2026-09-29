using System;
using UnityEngine;

public class GameManager : MonoBehaviour //usaremos el singleton
{
    public static GameManager Instance;

    [SerializeField] BallTwo ball;
    [SerializeField] Score score;
    [SerializeField] GameObject startButton;

    private void Awake()
    {
        //Esto es el patron singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject); <-- Esto hace que un singleton sea persistente
    }
    
    //el game manager debe controlar todos los estados de juego
    public void StartGame()
    {
        ball.StartGame();
        score.ResetScore();
        startButton.SetActive(false);
    }

    public void LeftGoal()
    {
        score.AddAIScore();
        CheckFinish();
    }

    public void RightGoal()
    {
        score.AddPlayerScore();
        CheckFinish();
    }
    
    private void CheckFinish()
    {
        ball.StopGame();
        if (score.IsFinished())
        {
            score.ResetScore();
            startButton.SetActive(true);
        }
        else
        {
            ball.StartGame();
        }
    }
    
}
