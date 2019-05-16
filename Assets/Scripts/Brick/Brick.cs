using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Brick : MonoBehaviour
{
    public Action<Brick> OnDeathAction;
    public Action<Brick> OnTargetReachedAction;
    public BrickType Type;

    [SerializeField]
    private int totalHP;
    private int currentHP;

    private Transform target;
    public int Score = 100;

    private void Start()
    {
        currentHP = totalHP;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        print("brick collision enter " + other.transform);
        if (other.transform.Equals(target))
        {
            if (OnTargetReachedAction != null)
                OnTargetReachedAction(this);
            return;
        }

        if (other.gameObject.GetComponent<Ball>() == null)
            return;

        currentHP -= 1;
        if (currentHP <= 0 && OnDeathAction != null)
            OnDeathAction(this);

    }

}
