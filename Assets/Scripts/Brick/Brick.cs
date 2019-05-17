﻿using System;
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
    public BrickConfig Config;

    private int currentHP;

    private Transform target;

    private void Start()
    {
        currentHP = Config.HP;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = Config.Color;
        renderer.sortingLayerName = SortingLayerName.GAMEPLAY;
    }

    public int Score
    {
        get { return Config.Score; }
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

        currentHP -= ballComponent.AttackPower; //Can be replaced with Ball
        if (currentHP <= 0 && OnDeathAction != null)
            OnDeathAction(this);

    }

}
