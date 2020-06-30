using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Attack
{
    protected override void TriggerAttack(){
        Collider2D[] toDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
        for (int i = 0; i < toDamage.Length; i++)
        {
            Debug.Log("melee");
            toDamage[i].GetComponent<Player>().Hit(damage);
        }
    }
}
