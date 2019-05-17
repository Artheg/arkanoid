using System;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Ball : MonoBehaviour
{
    public event Action<Collision2D> OnBallCollisionEnter;
    public Vector2 CurrentDirection { get; private set; }

    [SerializeField]
    private BallConfig config;
    private Rigidbody2D rb2d;
    private SpriteRenderer renderer;
    
    public int AttackPower
    {
        get
        {
            return config.AttackPower;
        }
    }

    public void Init()
    {
        InitRigidbody();
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = config.Color;
        renderer.sortingLayerName = SortingLayerName.GAMEPLAY;
    }

    private void InitRigidbody()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0f;
        rb2d.simulated = true;
        rb2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    public void ResetPosition()
    {
        transform.position = Vector2.zero;
    }

    public void StopMoving()
    {
        rb2d.velocity = Vector2.zero;
    }

    public void StartMoving(Vector2 direction)
    {
        ChangeDirection(direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (OnBallCollisionEnter != null)
            OnBallCollisionEnter(collision);
    }

    public void ChangeDirection(Vector2 direction)
    {
        CurrentDirection = direction;
        rb2d.velocity = direction * config.Speed;
    }
}
