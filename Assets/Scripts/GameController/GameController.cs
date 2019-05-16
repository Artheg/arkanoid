using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameModel gameModel;
    public UnityEvent OnGameStartEvent;
    public UnityEvent OnGameEndEvent;
    public UnityEvent OnDescendTickEvent;
    public Transform BadWall;
    public GameObject LevelPrefab;
    public BaseTransformController PlayerInputController;
    
    [SerializeField]
    private GameConfig gameConfig;

    private float timeSinceLastDescend;
    private Coroutine tickCoroutine;
    private BallController ballController;
    
    private BrickContainer brickContainer;

    public bool IsGameInProgress { get; private set; }

    void Start()
    {
        if (gameConfig == null)
            throw new UnityException("Trying to start the game with unassigned Game Config");
        if (PlayerInputController == null)
            throw new UnityException("Trying to start the game with unassigned Player Input Controller");

        PlayerInputController.AllowControls(false);
    }

    public void TryStartGame()
    {
        if (IsGameInProgress)
            return;
        IsGameInProgress = true;
        if (OnGameStartEvent != null)
            OnGameStartEvent.Invoke();
        
        gameModel.SetSecondsToDescend(gameConfig.BricksDescendPeriod);
        PlayerInputController.AllowControls(true);        
    }

    public void TryEndGame()
    {
        if (!IsGameInProgress)
            return;
        IsGameInProgress = false;
        
        if (OnGameEndEvent != null)
            OnGameEndEvent.Invoke();
        
        gameModel.SetSecondsToDescend(0f);
        PlayerInputController.AllowControls(false);                
    }

    void Update()
    {
        DecrementDescendTick();
    }

    private void DecrementDescendTick()
    {
        if (!IsGameInProgress)
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
