﻿using UnityEngine;
using Pathfinding;

public class PatrolEnemy : Enemy
{
    [Header("Patrol Enemy")]
    [SerializeField] private Transform[] patrolAnchors;
    private Transform currentAnchor;
    private int currentAnchorIndex;

    void Start()
    {
        currentAnchorIndex = 0;
        currentAnchor = patrolAnchors[currentAnchorIndex];
        aIDestination.target = currentAnchor;
    }

    void Update()
    {
        SetTarget();
    }

    protected override void SetTarget(){
        float dist = Vector2.Distance(this.transform.position, currentAnchor.transform.position);
        if (dist < 0.2){
            currentAnchorIndex = (currentAnchorIndex + 1) % patrolAnchors.Length;
            currentAnchor = patrolAnchors[currentAnchorIndex];
            aIDestination.target = currentAnchor;
        }
    }
}