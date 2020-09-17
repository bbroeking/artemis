using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAttackTrigger : AttackTrigger
{
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag(Tags.enemy)){
            this.target = collision.gameObject;
            attack.IsInRange = true;
            attack.targetInRange = collision.gameObject.transform;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(this.target == collision.gameObject){
            this.target = null;
            attack.IsInRange = false;
            attack.targetInRange = null;
        }
    }
}
