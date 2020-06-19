﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform primary;
    public Transform secondary;
    public GameObject sniperBullet;
    public GameObject gravityBullet;
    public Collider2D playerCollider;

    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public float internalAttackCooldown;
    private float timeBetweenAttack;
    public float bulletForce = 200f;
    // Update is called once per frame
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
            Cast(gravityBullet, secondary);
        }
    }

    void Melee(){
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().Hit();
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    void Cast(GameObject b, Transform firePoint)
    {
        GameObject bullet = Instantiate(b, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), playerCollider);

        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        Vector2 lookDir = worldPosition - rb.position;

        rb.AddForce(lookDir * bulletForce, ForceMode2D.Impulse);
    }
}
