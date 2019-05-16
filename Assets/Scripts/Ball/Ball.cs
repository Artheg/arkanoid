using System;
using UnityEngine;
using UnityEngine.Networking;

// Ball requires the GameObject to have a CircleCollider2D component
[RequireComponent(typeof(CircleCollider2D))]
// Ball requires the GameObject to have a RigidBody2D component
[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public Action<Collision2D> OnBallCollisionEnter;
    public float Speed;
    public Vector2 CurrentDirection { get; private set; }
    private Rigidbody2D rb2d;
    
    public void Init()
    {
        InitRigidbody();
    }

    private void InitRigidbody()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0f;
        rb2d.simulated = true;
        rb2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    internal void ResetPosition()
    {
        transform.position = Vector2.zero;
    }

    internal void StopMoving()
    {
        rb2d.velocity = Vector2.zero;
        print("Ball has stopped moving");
    }

    internal void StartMoving(Vector2 direction)
    {
        ChangeDirection(direction);
    }

    void OnCollisionEnter2D(Collision2D collision)
    { 
        if (OnBallCollisionEnter != null)
            OnBallCollisionEnter(collision);
    }

    public void ChangeDirection(Vector2 direction)
    {
        CurrentDirection = direction;
        rb2d.velocity = direction * Speed;
    }
}
