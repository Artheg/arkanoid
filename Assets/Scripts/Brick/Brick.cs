using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
[RequireComponent(typeof(BoxCollider2D))]
public class Brick : MonoBehaviour
{
    public event Action<Brick> OnDeathAction;
    public event Action<Brick> OnTargetReachedAction;
    
    [SerializeField]
    private BrickConfig config;

    private int currentHP;

    private Transform target;

    private void Start()
    {
        currentHP = config.HP;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = config.Color;
        renderer.sortingLayerName = SortingLayerName.GAMEPLAY;
    }

    public int Score
    {
        get { return config.Score; }
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
        Ball ballComponent = other.gameObject.GetComponent<Ball>();
        if (ballComponent == null)
            return;

        currentHP -= ballComponent.AttackPower;
        if (currentHP <= 0 && OnDeathAction != null)
            OnDeathAction(this);

    }

}
