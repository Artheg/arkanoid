using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public UnityEvent OnGameStartEvent;
    public UnityEvent OnGameEndEvent;
    public UnityEvent OnDescendTickEvent;

    [SerializeField]
    private BaseTransformController playerInputController;
    
    [SerializeField]
    private GameModel gameModel;

    [SerializeField]
    private GameConfig gameConfig;

    private float timeSinceLastDescend;
    private Coroutine tickCoroutine;
    private bool isGameInProgress;

    void Start()
    {
        if (gameConfig == null)
            throw new UnityException("Trying to start the game with unassigned Game Config");
        if (playerInputController == null)
            throw new UnityException("Trying to start the game with unassigned Player Input Controller");

        playerInputController.AllowControls(false);
    }

    public void TryStartGame()
    {
        if (isGameInProgress)
            return;
        isGameInProgress = true;
        if (OnGameStartEvent != null)
            OnGameStartEvent.Invoke();
        
        gameModel.SetSecondsToDescend(gameConfig.BricksDescendPeriod);
        playerInputController.AllowControls(true);        
    }

    public void TryEndGame()
    {
        if (!isGameInProgress)
            return;
        isGameInProgress = false;
        
        if (OnGameEndEvent != null)
            OnGameEndEvent.Invoke();
        
        gameModel.SetSecondsToDescend(0f);
        playerInputController.AllowControls(false);                
    }

    void Update()
    {
        DecrementDescendTick();
    }

    private void DecrementDescendTick()
    {
        if (!isGameInProgress)
            return;
        float timeLeft = gameModel.DescendSecondsLeft;
        if (timeLeft < 0)
        {
            gameModel.SetSecondsToDescend(gameConfig.BricksDescendPeriod);
            OnDescendTickEvent.Invoke();
            return;
        }

        gameModel.SetSecondsToDescend(timeLeft - Time.deltaTime);
    }
}
