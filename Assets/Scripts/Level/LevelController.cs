using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour, IController
{
    public UnityEvent OnTargetReachedEvent;
    public GameObject LevelPrefab;
    public Transform LevelContainer;

    public Transform EnemyTarget;
    private BrickContainer currentLevel;

    [SerializeField]
    private GameModel gameModel;

    public void OnGameStart()
    {
        GameObject level = Instantiate(LevelPrefab, LevelContainer);
        currentLevel = level.GetComponent<BrickContainer>();
        currentLevel.InitBricks(EnemyTarget);
        currentLevel.SetModel(gameModel);
        currentLevel.OnTargetReachedEvent.AddListener(OnTargetReachedEvent.Invoke);
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
