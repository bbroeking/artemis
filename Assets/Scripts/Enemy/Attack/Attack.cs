using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("Attack")]
    // [SerializeField] private Animator anim;
    // [SerializeField] protected Transform attackPos;
    // [SerializeField] protected LayerMask whatIsEnemy;
    // [SerializeField] protected int damage;
    // protected Player player;
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
            //anim.SetTrigger("Attack");
            TriggerAttack();
            internalCooldown = baseCooldown;
        } else {
            internalCooldown -= Time.deltaTime;
        }
    }

    protected virtual void TriggerAttack(){
        Debug.LogWarning("Trigger Attack funciton is not implemented for object");
    }
}