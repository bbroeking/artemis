using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("Attack")]
    public float baseCooldown = 2f;
    private float internalCooldown;
    private bool isInRange;
    public bool IsInRange { get { return isInRange; } set { isInRange = value; } }
    public Transform targetInRange;
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

    protected virtual void TriggerAttack(){
        Debug.LogWarning("Trigger Attack funciton is not implemented for object");
    }
}