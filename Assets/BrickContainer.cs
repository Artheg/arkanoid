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

    public void InitBricks(Transform target)
    {
        bricks = new List<Brick>();
        GetComponentsInChildren<Brick>(bricks);

        for (int i = 0; i < bricks.Count; i++)
        {
            Brick brick = bricks[i];
            brick.OnTargetReachedAction += OnTargetReached;
            brick.OnDeathAction += OnBrickDead;
        }
    }

    private void OnTargetReached(Brick brick)
    {
        if (OnTargetReachedEvent != null)
            OnTargetReachedEvent.Invoke();
    }

    public void Descend()
    {
        transform.position -= new Vector3(0, 0.5f, 0f);
    }

    private void OnBrickDead(Brick brick)
    {
        Destroy(brick.gameObject);
        bricks.Remove(brick);
        if (bricks.Count == 0 && OnAllBricksDeadEvent != null)
            OnAllBricksDeadEvent.Invoke();
    }
}
