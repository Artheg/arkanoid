using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallController
{
    public UnityAction<Ball> OnBallSpawned;

    private Ball currentBall;
    private BallSpawner ballSpawner;

    private Dictionary<Collision2D, BasePaddle> paddles;
    private List<Collision2D> regularCollisions;

    public BallController(BallSpawner ballSpawner)
    {
        this.ballSpawner = ballSpawner;
        ballSpawner.OnBallSpawnDone += OnBallSpawnDone;

        paddles = new Dictionary<Collision2D, BasePaddle>();
        regularCollisions = new List<Collision2D>();
    }

    public void OnGameStart()
    {
        ballSpawner.SpawnRandomBall();
      
    }

    private void OnBallSpawnDone(Ball ball)
    {
        currentBall = ball;

        var x = Random.Range(-1f, 1f);
        Vector2 direction = new Vector2(x, -1f);

        currentBall.OnBallCollisionEnter += OnBallCollides;
        currentBall.StartMoving(direction);

        if (OnBallSpawned != null)
            OnBallSpawned(ball);
    }

    public void OnGameEnd()
    {
        currentBall.OnBallCollisionEnter -= OnBallCollides;
        currentBall.StopMoving();
        currentBall.ResetPosition();
        ballSpawner.DisposeBall(currentBall);
        currentBall = null;
    }

    private void OnBallCollides(Collision2D collision)
    {
        if (regularCollisions.Contains(collision))
        {
            OnRegularCollision(collision);
            return;
        }

        BasePaddle paddle;
        paddles.TryGetValue(collision, out paddle);

        //If no paddle in dictionary, try get one from current collision
        if (paddle == null)
            paddle = collision.gameObject.GetComponent<BasePaddle>();

        if (paddle != null) //If it's a paddle
        {
            OnPaddleCollision(paddle, collision);
            if (!paddles.ContainsValue(paddle))
                paddles.Add(collision, paddle);
        }
        else //If it's not a paddle, then it's a first-time regular collision
        {
            regularCollisions.Add(collision);
            OnRegularCollision(collision);
        }
     
    }

    private void OnRegularCollision(Collision2D collision)
    {
        Vector2 direction = Vector2.Reflect(currentBall.CurrentDirection, collision.contacts[0].normal);
        currentBall.ChangeDirection(direction.normalized);
    }

    private void OnPaddleCollision(BasePaddle paddle, Collision2D collision)
    {
        Vector2 direction = paddle.CalculateBallDirection(collision, currentBall.CurrentDirection);
        currentBall.ChangeDirection(direction.normalized);
    }
}
