using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackTrigger : MonoBehaviour
{
    [SerializeField] MeleeAttack melee;
    void OnValidate(){
        melee = GetComponentInParent<MeleeAttack>();
    }
    void OnTriggerEnter2D(){
        melee.IsInRange = true;
    }

    void OnTriggerExit2D(){
        melee.IsInRange = false;
    }
}
