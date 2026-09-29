using UnityEngine;

public class GameManagerAdvanced : MonoBehaviour
{
    public static GameManagerAdvanced Instance;
    
    public delegate void OnGameEvent(); //caben metodos que no devuelven nada y no tienen parametros de entrada
    public event OnGameEvent OnGameStart;
    public event OnGameEvent OnGameStop;


    public delegate void OnScoreEvent(int playerScore, int AIscore);
    public event OnScoreEvent OnPlayerScore;
    public event OnScoreEvent OnAIScore;
    public event OnScoreEvent OnResetScore;

    [SerializeField] private int maxScore = 3;

    private int playerScore;
    private int aiScore;
    
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
    }
    
    public void StartGame()
    {
        OnGameStart?.Invoke(); //checkeamos a null y luego lo invocamos
        ResetScore();
    }

    
    public void LeftGoal()
    {
        AddAIScore();
    }

    private void AddAIScore()
    {
        aiScore++;
        OnAIScore?.Invoke(playerScore, aiScore);
        CheckFinish();
    }

    public void RightGoal()
    {
        AddPlayerScore();
    }

    private void AddPlayerScore()
    {
        playerScore++;
        OnPlayerScore?.Invoke(playerScore, aiScore);
        CheckFinish();
    }

    private void CheckFinish()
    {
        if (isFinised())
        {
            OnGameStop?.Invoke();
        }
        else
        {
            OnGameStart?.Invoke();
        }
    }

    private bool isFinised()
    {
        return aiScore >= maxScore || playerScore >= maxScore;
    }

    private void ResetScore()
    {
        aiScore = 0;
        playerScore = 0;
        OnResetScore?.Invoke(playerScore, aiScore);
    }

}
