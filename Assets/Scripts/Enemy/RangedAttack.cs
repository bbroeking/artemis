using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : Attack
{
    [Header("Ranged Attack")]
    [SerializeField] GameObject projectile;
    [SerializeField] Collider2D chracterCollider;
    void OnValidate(){
        chracterCollider = GetComponentInParent<Collider2D>();
    }
    protected override void TriggerAttack(){
        float force = 4f;
        for (int i = 0; i < 6; i++)
        {
            GameObject spell = Instantiate(projectile, attackPos.position, Quaternion.identity);
            Destroy(spell, 3);
            Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
            Physics2D.IgnoreCollision(spell.GetComponent<Collider2D>(), chracterCollider);
            rb.AddForce((Quaternion.Euler(0, 0, (60f*i)) * Vector2.up) * force, ForceMode2D.Impulse);
        }
    }
}
