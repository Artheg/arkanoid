using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallSpawner : MonoBehaviour
{
    public UnityAction<Ball> OnBallSpawnDone;

    [SerializeField]
    private List<GameObject> ballPrefabs = new List<GameObject>();

    void Start()
    {
        if (ballPrefabs.Count == 0)
            throw new Exception("Add some ball prefabs to the list!");
    }

    public void SpawnRandomBall()
    {
        var ballPrefab = ballPrefabs[UnityEngine.Random.Range(0, ballPrefabs.Count)];

        var ballGameObject = Instantiate(ballPrefab);
        Ball ballComponent = ballGameObject.GetComponent<Ball>();

        if (ballComponent == null)
            throw new Exception("Ball prefab " + ballPrefab.name + " doesn't have a Ball script component");

        ballComponent.Init();

        if (OnBallSpawnDone != null)
            OnBallSpawnDone(ballComponent);
    }

    public void DisposeBall(Ball ball)
    {
        Destroy(ball.gameObject);
    }
}
