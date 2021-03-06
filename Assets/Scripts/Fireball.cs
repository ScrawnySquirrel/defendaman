﻿using UnityEngine;
using System.Collections;
using System;

public class Fireball : Projectile
{
    private Vector2 startPos;
    public int maxDistance;

    //projectile speed

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (Vector2.Distance(startPos, transform.position) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.GetComponent<BaseClass>() != null && teamID != other.gameObject.GetComponent<BaseClass>().team)
        {
            var burn = other.gameObject.GetComponent<Burn>();
            if (burn == null)
            {
                other.gameObject.AddComponent<Burn>();
            }
            else
            {
                burn.duration = 600;
            }
        }
    }
}
