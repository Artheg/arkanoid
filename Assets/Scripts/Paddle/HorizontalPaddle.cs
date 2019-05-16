
using UnityEngine;
// HorizontalPaddle requires the GameObject to have a BoxCollider2D component
[RequireComponent(typeof(BoxCollider2D))]
public class HorizontalPaddle : BasePaddle
{
    private BoxCollider2D boxCollider;
    private Vector2 previousPos;
    private Vector2 currentVelocity;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        var currentPos = new Vector2(transform.position.x, transform.position.y);
        currentVelocity = (currentPos - previousPos) / Time.deltaTime;
        previousPos = transform.position;
    }

    public override Vector2 CalculateBallDirection(Collision2D collision, Vector2 ballDirection)
    {
        Vector2 reflection = Vector2.Reflect(ballDirection, collision.contacts[0].normal);
        Vector2 normalizedVelocity = currentVelocity.normalized;

        return (reflection + normalizedVelocity).normalized * 0.5f;
    }
}
