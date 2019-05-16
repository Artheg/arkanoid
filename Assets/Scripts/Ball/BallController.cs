using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallSpawner))]
public class BallController : MonoBehaviour, IController
{
    public UnityAction<Ball> OnBallSpawned;

    private Ball currentBall;
    private BallSpawner ballSpawner;

    [SerializeField]
    private GameModel gameModel;

    private Dictionary<Collision2D, BasePaddle> paddles;
    private List<Collision2D> regularCollisions;

    void Start()
    {
        this.ballSpawner = GetComponent<BallSpawner>();
        ballSpawner.OnBallSpawnDone += OnBallSpawnDone;

        paddles = new Dictionary<Collision2D, BasePaddle>();
        regularCollisions = new List<Collision2D>();

        if (!gameModel)
            Debug.LogWarning("BallController: GameModel is not set. Looks like you're testing something, eh?");
    }

    public void OnGameStart()
    {
        ballSpawner.SpawnRandomBall();
    }

    private void OnBallSpawnDone(Ball ball)
    {
        currentBall = ball;

        var x = Random.Range(-1f, 1f);
        Vector2 direction = new Vector2(0, -1f);

        currentBall.OnBallCollisionEnter += OnBallCollides;
        currentBall.StartMoving(direction);

        if (OnBallSpawned != null)
            OnBallSpawned(ball);
    }

    public void OnGameEnd()
    {
        print("Ball controller: on game end");
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
