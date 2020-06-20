﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Transform attackPos;
    public Transform castPos;
    public GameObject gravitySoul;
    public Collider2D playerCollider;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public float internalAttackCooldown;
    public float spellForce;
    private float timeBetweenAttack;
    [SerializeField]
    private GameObject poisonNova;
    [SerializeField]
    private Spellbook spellbook;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(timeBetweenAttack <= 0){
                Melee();
                timeBetweenAttack = internalAttackCooldown;
            } else {
                timeBetweenAttack -= Time.deltaTime;
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Cast(gravitySoul, castPos);
            this.GetComponent<Player>().UseEssence(1);
        }
    }

    void Melee(){
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().Hit();
        }
    }

    public void UseSoulAbility(Soul activeSoul){
        if (activeSoul == Soul.poison){
            spellbook.CastPoisonNova(poisonNova, castPos.transform, playerCollider, 10f);
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    void Cast(GameObject b, Transform firePoint)
    {
        GameObject spell = Instantiate(b, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(spell.GetComponent<Collider2D>(), playerCollider);

        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        Vector2 lookDir = worldPosition - rb.position;

        rb.AddForce(lookDir * spellForce, ForceMode2D.Impulse);
    }
}
