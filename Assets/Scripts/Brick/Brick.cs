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

    [SerializeField]
    private int totalHP;
    private int currentHP;

    private Transform target;

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
        if (other.transform.Equals(target))
        {
            if (OnTargetReachedAction != null)
                OnTargetReachedAction(this);
            return;
        }


        currentHP -= 1;
        if (currentHP <= 0 && OnDeathAction != null)
            OnDeathAction(this);

    }

}
