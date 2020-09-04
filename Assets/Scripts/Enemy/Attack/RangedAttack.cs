using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : Attack
{
    [Header("Ranged Attack")]
    [SerializeField] private GameObject projectile;
    private Collider2D ignoredCharacterCollider;

    void Start(){
        ignoredCharacterCollider = GetComponent<Collider2D>();
    }
    protected override void TriggerAttack(){
        for (int i = 0; i < 6; i++)
        {
            GameObject spell = Instantiate(projectile, this.transform.position, Quaternion.identity);
            Projectile proj = spell.GetComponent<Projectile>();
            proj.ZRotation = 60f * i;
            Physics2D.IgnoreCollision(spell.GetComponent<Collider2D>(), ignoredCharacterCollider);
        }
    }
}
