
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameModel : MonoBehaviour
{
    public UnityEvent OnDescendSecondsChangeEvent;
    public UnityEvent OnScoreChangeEvent;

    public UnityEvent OnGameLostEvent;
    public UnityEvent OnGameWonEvent;

    public GameStatus Status {get; private set; }
    public int Score {get; private set; }
    public bool IsGameInProgress {get; private set; }
    public float DescendSecondsLeft {get; private set; }
    
    public void SetSecondsToDescend(float value)
    {
        DescendSecondsLeft = value;
        if (OnDescendSecondsChangeEvent != null)
            OnDescendSecondsChangeEvent.Invoke();
    }

    public void ChangeScore(int delta)
    {
        Score += delta;
        if (OnScoreChangeEvent != null)
            OnScoreChangeEvent.Invoke();
    }

    public void ResetScore()
    {
        Score = 0;
        if (OnScoreChangeEvent != null)
            OnScoreChangeEvent.Invoke();
    }

    public void SetSatus(GameStatus status)
    {
        Status = status;
    }

    public void OnGameWon()
    {
        ChangeScore(100);
        if (OnGameWonEvent != null)
            OnGameLostEvent.Invoke();
    }

    public void OnGameLost()
    {
        ResetScore();
        Status = GameStatus.FAIL;
        if (OnGameLostEvent != null)
            OnGameLostEvent.Invoke();
    }
}