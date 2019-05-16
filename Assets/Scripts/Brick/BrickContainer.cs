using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BrickContainer : MonoBehaviour
{
    public UnityEvent OnAllBricksDeadEvent;
    public UnityEvent OnTargetReachedEvent;
    private List<Brick> bricks;
    private GameModel gameModel;

    public void InitBricks(Transform target)
    {
        bricks = new List<Brick>();
        GetComponentsInChildren<Brick>(bricks);

        for (int i = 0; i < bricks.Count; i++)
        {
            Brick brick = bricks[i];
            brick.SetTarget(target);
            brick.OnTargetReachedAction += OnTargetReached;
            brick.OnDeathAction += OnBrickDead;
        }
    }

    public void SetModel(GameModel gameModel = null)
    {
        this.gameModel = gameModel;
    }

    private void OnTargetReached(Brick brick)
    {
        if (OnTargetReachedEvent != null)
            OnTargetReachedEvent.Invoke();
        if (gameModel != null)
            gameModel.OnGameLost();
        else
            Debug.LogWarning("LevelController.BrickContainer: Game model not set. Testing?");
    }

    public void Descend()
    {
        transform.position -= new Vector3(0, 0.5f, 0f);
    }

    private void OnBrickDead(Brick brick)
    {
        Destroy(brick.gameObject);
        bricks.Remove(brick);
        if (gameModel != null)
        {
            gameModel.ChangeScore(brick.Score);
            if (bricks.Count == 0)
                gameModel.OnGameWon();
        }
        else
            Debug.LogWarning("LevelController.BrickContainer: Game model not set. Testing?");
    }
}
