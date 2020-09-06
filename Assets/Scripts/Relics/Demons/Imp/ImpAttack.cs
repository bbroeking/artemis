using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpAttack : Attack
{
    [Header("Imp Attack")]
    [SerializeField] private GameObject projectile;
    private Collider2D ignoredCharacterCollider;

    void Start(){
        ignoredCharacterCollider = GetComponent<Collider2D>();
    }
    protected override void TriggerAttack(){
        for (int i = 0; i < 3; i++)
        {
            GameObject spell = Instantiate(projectile, this.transform.position, Quaternion.identity);
            Projectile proj = spell.GetComponent<Projectile>();
            proj.Direction = targetInRange.position.normalized;
            proj.ZRotation = 15f * i;
            Physics2D.IgnoreCollision(spell.GetComponent<Collider2D>(), ignoredCharacterCollider);
        }
    }
}
