using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : Attack
{
    [Header("Ranged Attack")]
    [SerializeField] private GameObject projectile;
    private Collider2D ignoredCharacterCollider;
    private int PROJECTILE_OBJECT_POOL_INDEX = 6;
    void Start(){
        ignoredCharacterCollider = GetComponent<Collider2D>();
    }
    protected override void TriggerAttack(){
        for (int i = 0; i < 6; i++)
        {
            GameObject GO = ObjectPooler.SharedInstance.GetPooledObject(PROJECTILE_OBJECT_POOL_INDEX);
            Projectile proj = GO.GetComponent<Projectile>();
            proj.ZRotation = 60f * i;
            ProjectileHelpers.ObjectIgnores(GO, ignoredCharacterCollider);
        }
    }
}
