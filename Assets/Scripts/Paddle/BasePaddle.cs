using System;
using UnityEngine;

public class BasePaddle : MonoBehaviour
{
    public void UpdatePosition(Vector2 newPos)
    {
        transform.position = newPos;
    }

    public virtual Vector2 CalculateBallDirection(Collision2D collision, Vector2 ballDirection)
    {
        throw new NotImplementedException();
    }
}
