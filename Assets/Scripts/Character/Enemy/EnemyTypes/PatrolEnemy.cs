using UnityEngine;
using Pathfinding;
using System.Collections.Generic;

public class PatrolEnemy : Enemy
{
    [Header("Patrol Enemy")]
    [SerializeField] private List<Transform> patrolAnchors;
    private Transform currentAnchor;
    private int currentAnchorIndex;

    protected override void Start()
    {
        currentAnchorIndex = 0;
        StartCoroutine(ActivateEnemyDelay());
        GeneratePatrolAnchors();
    }

    protected override void Update()
    {
        if (!isActivateDelay){
            currentAnchor = patrolAnchors[currentAnchorIndex];
            aIDestination.target = currentAnchor;
            SetTarget();
        }
        UpdateAnimationValues();
    }

    protected override void SetTarget(){
        float dist = Vector2.Distance(this.transform.position, currentAnchor.transform.position);
        if (dist < 0.5){
            currentAnchorIndex = (currentAnchorIndex + 1) % patrolAnchors.Count;
            currentAnchor = patrolAnchors[currentAnchorIndex];
            aIDestination.target = currentAnchor;
        }
    }

    protected void GeneratePatrolAnchors(){
        // general room are -7, 7 and -3, 3 
        for(int i = 0; i <= 4; i++){
            var go = new GameObject("Anchor" + i.ToString());
            go.transform.position = new Vector3(Random.Range(-7,7),
                                                Random.Range(-3,3), 0);
            patrolAnchors.Add(go.transform);
        }
        
    }
}
