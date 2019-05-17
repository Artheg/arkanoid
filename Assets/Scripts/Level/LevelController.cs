using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour, IController
{
    [SerializeField]
    private UnityEvent onTargetReachedEvent;
    [SerializeField]
    private GameObject levelPrefab;
    [SerializeField]
    private Transform levelContainer;

    [SerializeField]
    private Transform enemyTarget;
    private BrickContainer currentLevel;

    [SerializeField]
    private GameModel gameModel;
    [SerializeField]
    private LevelGenerator levelGenerator;


    public void OnGameStart()
    {
        GameObject level = (levelGenerator != null) ? levelGenerator.GenerateLevel(levelContainer) : Instantiate(levelPrefab, levelContainer);
        currentLevel = level.GetComponent<BrickContainer>();
        currentLevel.InitBricks(enemyTarget);
        currentLevel.SetModel(gameModel);
        currentLevel.OnTargetReachedAction += onTargetReachedEvent.Invoke;
    }

    public void OnGameEnd()
    {
        Destroy(currentLevel.gameObject);
    }

    public void OnDescendTick()
    {
        currentLevel.Descend();
    }
}
