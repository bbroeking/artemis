using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] Transform attackPos;
    // public Collider2D playerCollider;
    [SerializeField] LayerMask whatIsEnemy;
    [SerializeField] float attackRange;
    [SerializeField] int damage;
    public float cooldown = 2f;
    private float internalCD;
    private bool isInRange;
    public bool IsInRange { get { return isInRange; } set { isInRange = value; } }

    void Start()
    {
        internalCD = 0;
        isInRange = false;
    }

    void Update()
    {
        if(internalCD <= 0 && isInRange){
            Melee();
            internalCD = cooldown;
        } else {
            internalCD -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void Melee(){
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<PlayerResources>().TakeDamage(damage);
        }
    }
}
