using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : Attack
{
    [Header("Ranged Attack")]
    [SerializeField] GameObject projectile;
    [SerializeField] Collider2D chracterCollider;
    [SerializeField] Enemy enemy;

    void Start(){
        chracterCollider = GetComponent<Collider2D>();
        enemy = GetComponent<Enemy>();
    }
    protected override void TriggerAttack(){
        for (int i = 0; i < 6; i++)
        {
            GameObject spell = Instantiate(projectile, enemy.transform.position, Quaternion.identity);
            Projectile pj = spell.GetComponent<Projectile>();
            pj.ZRotation = 60f * i;
            Physics2D.IgnoreCollision(spell.GetComponent<Collider2D>(), chracterCollider);
        }
    }
}
