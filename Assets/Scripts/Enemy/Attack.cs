using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] protected Transform attackPos;
    [SerializeField] protected LayerMask whatIsEnemy;
    [SerializeField] protected float attackRange;
    [SerializeField] protected int damage;
    public float baseCooldown = 2f;
    private float internalCooldown;
    private bool isInRange;
    public bool IsInRange { get { return isInRange; } set { isInRange = value; } }

    void Start()
    {
        internalCooldown = 0;
        isInRange = false;
    }

    void Update()
    {
        if(internalCooldown <= 0 && isInRange){
            TriggerAttack();
            internalCooldown = baseCooldown;
        } else {
            internalCooldown -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    protected virtual void TriggerAttack(){
        return;
    }
}