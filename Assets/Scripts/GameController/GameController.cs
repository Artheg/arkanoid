using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallSpawner))]
public class GameController : MonoBehaviour
{
    public UnityEvent OnDescendTick;
    public Transform BadWall;
    public GameObject LevelPrefab;
    private GameObject level;
    
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
        ballController = new BallController(GetComponent<BallSpawner>());

        TryStartGame();
    }

    public void TryStartGame()
    {
        if (IsGameInProgress)
            return;
        ballController.OnGameStart();
        IsGameInProgress = true;

        brickContainer = Instantiate(LevelPrefab).GetComponent<BrickContainer>();
        brickContainer.InitBricks(BadWall);
        
        OnDescendTick.AddListener(brickContainer.Descend);
        
    }

    public void EndGame()
    {
        OnDescendTick.RemoveListener(level.GetComponent<BrickContainer>().Descend);

        ballController.OnGameEnd();
        IsGameInProgress = false;
        Destroy(level);
    }

    void FixedUpdate()
    {
        TryProcessTick();
    }

    private void TryProcessTick()
    {
        if (tickCoroutine != null)
            return;
        tickCoroutine = StartCoroutine(ProcessTick());
    }

    private IEnumerator ProcessTick()
    {
        yield return new WaitForSeconds(gameConfig.BricksDescendPeriod);
        if (OnDescendTick != null)
            OnDescendTick.Invoke();
        tickCoroutine = null;

    }
}
